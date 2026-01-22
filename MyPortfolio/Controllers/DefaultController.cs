using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Context;
using SelectPdf;

namespace MyPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        private readonly MyPortfolioContext _context;

        public DefaultController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DownloadCV()
        {
            var about = _context.Abouts.FirstOrDefault();
            var educations = _context.Educations.OrderByDescending(x => x.EducationDate).ToList();
            var experiences = _context.Experiences.ToList();
            var skills = _context.Skills.ToList();

            // HTML içeriği
            string html = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>CV - {about?.NameSurname ?? "CV"}</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 40px;
            color: #333;
        }}
        h1 {{
            color: #6366f1;
            border-bottom: 3px solid #22d3ee;
            padding-bottom: 10px;
        }}
        h2 {{
            color: #6366f1;
            margin-top: 30px;
            border-bottom: 2px solid #e0e0e0;
            padding-bottom: 5px;
        }}
        .section {{
            margin-bottom: 30px;
        }}
        .about-info {{
            margin-bottom: 20px;
        }}
        .about-info p {{
            margin: 5px 0;
        }}
        .education-item, .experience-item {{
            margin-bottom: 20px;
            padding: 15px;
            background-color: #f9f9f9;
            border-left: 4px solid #6366f1;
        }}
        .education-item h3, .experience-item h3 {{
            margin: 0 0 5px 0;
            color: #1a1a1a;
        }}
        .education-item p, .experience-item p {{
            margin: 3px 0;
            color: #666;
        }}
        .skills-list {{
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
        }}
        .skill-item {{
            background-color: #6366f1;
            color: white;
            padding: 8px 15px;
            border-radius: 5px;
            font-weight: bold;
        }}
        table {{
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }}
        table th, table td {{
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }}
        table th {{
            background-color: #6366f1;
            color: white;
        }}
    </style>
</head>
<body>
    <h1>{about?.NameSurname ?? "CV"}</h1>
    
    <div class='section about-info'>
        <p><strong>Ünvan:</strong> {about?.Title ?? ""}</p>
        <p><strong>Açıklama:</strong> {about?.Description ?? ""}</p>
    </div>";

            // Eğitim 
            if (educations.Any())
            {
                html += @"
    <div class='section'>
        <h2>Eğitim</h2>";
                foreach (var edu in educations)
                {
                    html += $@"
        <div class='education-item'>
            <h3>{edu.Title}</h3>
            <p><strong>Alt Başlık:</strong> {edu.Subtitle}</p>
            <p><strong>Tarih:</strong> {edu.EducationDate:yyyy-MM-dd}</p>
            <p>{edu.Description}</p>
        </div>";
                }
                html += @"
    </div>";
            }

            // Deneyim 
            if (experiences.Any())
            {
                html += @"
    <div class='section'>
        <h2>Deneyim</h2>";
                foreach (var exp in experiences)
                {
                    html += $@"
        <div class='experience-item'>
            <h3>{exp.Title}</h3>
            <p><strong>Pozisyon:</strong> {exp.WorkTitle}</p>
            <p><strong>Tarih:</strong> {exp.WorkDate}</p>
            <p>{exp.Description}</p>
        </div>";
                }
                html += @"
    </div>";
            }

            // Yetenekler
            if (skills.Any())
            {
                html += @"
    <div class='section'>
        <h2>Yetenekler</h2>
        <table>
            <thead>
                <tr>
                    <th>Yetenek</th>
                    <th>Seviye</th>
                </tr>
            </thead>
            <tbody>";
                foreach (var skill in skills)
                {
                    html += $@"
                <tr>
                    <td>{skill.Title}</td>
                    <td>{skill.SkillValue}%</td>
                </tr>";
                }
                html += @"
            </tbody>
        </table>
    </div>";
            }

            html += @"
</body>
</html>";

            // PDF'e çevir
            HtmlToPdf pdf = new HtmlToPdf();
            PdfDocument pdfDocument = pdf.ConvertHtmlString(html);

            // PDF'i byte array'e çevir
            byte[] pdfBytes = pdfDocument.Save();
            pdfDocument.Close();

            // PDF'i indir
            return File(pdfBytes, "application/pdf", "Aykut_CV" + ".pdf");
        }
    }
}
