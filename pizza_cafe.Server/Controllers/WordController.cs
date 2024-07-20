using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using pizza_cafe.Server.Services;
using pizza_cafe.Shared.Models;

namespace pizza_cafe.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordController(WordService wordService) : ControllerBase
{
    private readonly WordService _wordService = wordService;


    [HttpPost("Generate")]
    public IActionResult GenerateWord([FromBody] Cart cart, string fileName)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Creating a document
            using (WordprocessingDocument wordDocument =
                   WordprocessingDocument.Create(memoryStream, WordprocessingDocumentType.Document, true))
            {
                // Adding the main body of the document
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = new Body();

                Paragraph paragraph = new Paragraph();
                Run run = new Run(new Text("Страви які ви обрали!"));

                RunProperties runProperties = new RunProperties();
                runProperties.Bold = new Bold();
                runProperties.FontSize = new FontSize() { Val = "35" };
                runProperties.RunFonts = new RunFonts() { Ascii = "Times New Roman" };

                run.PrependChild(runProperties);
                paragraph.Append(run);

                ParagraphProperties paragraphProperties = new ParagraphProperties();
                Justification justification = new Justification() { Val = JustificationValues.Center };
                paragraphProperties.Append(justification);

                paragraph.Append(paragraphProperties);

                body.Append(paragraph);

                // Creating a table
                Table table = new Table();

                // Create table properties and add borders
                TableProperties tblProperties = new TableProperties(
                    new TableBorders(
                        new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new InsideHorizontalBorder
                            { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 }
                    )
                );

                table.AppendChild(tblProperties);


                //Header of Table 
                TableRow row = new TableRow();
                row.AppendChild(CreateTableCell("Назва", "2400", true, "27"));
                row.AppendChild(CreateTableCell("Ціна порції(грн)", "2400", true, "27"));
                row.AppendChild(CreateTableCell("Кількість(шт)", "2400", true, "27"));
                row.AppendChild(CreateTableCell("Ціна(грн)", "2400", true, "27"));

                table.Append(row);

                // Add rows and cells to a table
                foreach (var item in cart.CartItems)
                {
                    TableRow dataRow = new TableRow();
                    dataRow.Append(CreateTableCell(item.Dish.Name, "2400", false, "27"));
                    dataRow.Append(CreateTableCell($"{item.Dish.Price.ToString()} грн", "2400", false, "27"));
                    dataRow.Append(CreateTableCell($"{item.Count.ToString()} шт", "2400", false, "27"));
                    dataRow.Append(CreateTableCell($"{item.Price.ToString()} грн", "2400", false, "27"));
                    table.Append(dataRow);
                }
                
                // Adding a table to the document body
                body.Append(table);
                
                body.Append(CreateParagraph($"Разом: {cart.Price} грн", true, "33", JustificationValues.Right));
                
                mainPart.Document.Append(body);
            }

            var newFile = File(memoryStream.ToArray(),
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"{fileName}.docx");

            return newFile;
        }
    }

    public TableCell CreateTableCell(string text, string width, bool isBold, string fontSize)
    {
        TableCell cell = new TableCell();
        Paragraph paragraph = new Paragraph();
        Run run = new Run(new Text(text));

        RunProperties runProperties = new RunProperties();

        if (isBold)
            runProperties.Bold = new Bold();

        runProperties.FontSize = new FontSize() { Val = fontSize };
        runProperties.RunFonts = new RunFonts() { Ascii = "Times New Roman" };

        run.PrependChild(runProperties);
        paragraph.Append(run);
        cell.Append(paragraph);

        cell.Append(new TableCellProperties(new TableCellWidth
        {
            Type = TableWidthUnitValues.Dxa,
            Width = width
        }));

        TableCellMargin margin = new TableCellMargin();
        margin.LeftMargin = new LeftMargin() { Width = "200", Type = TableWidthUnitValues.Dxa };
        margin.RightMargin = new RightMargin() { Width = "200", Type = TableWidthUnitValues.Dxa };
        margin.TopMargin = new TopMargin() { Width = "200", Type = TableWidthUnitValues.Dxa };
        margin.BottomMargin = new BottomMargin() { Width = "200", Type = TableWidthUnitValues.Dxa };

        cell.Append(new TableCellProperties(margin));

        return cell;
    }
    
    public Paragraph CreateParagraph(string text, bool isBold, string fontSize, JustificationValues justificationValues)
    {
        Paragraph paragraph = new Paragraph();
        Run run = new Run(new Text(text));

        // Setting the text style
        RunProperties runProperties = new RunProperties();

        // Text style
        if (isBold)
            runProperties.Bold = new Bold();

        // Font size and font type
        runProperties.FontSize = new FontSize() { Val = fontSize };
        runProperties.RunFonts = new RunFonts() { Ascii = "Times New Roman" };

        run.PrependChild(runProperties);
        paragraph.Append(run);

        // Setting text alignment to center
        ParagraphProperties paragraphProperties = new ParagraphProperties();
        Justification justification = new Justification() { Val = justificationValues };

        paragraphProperties.Append(justification);
        paragraph.Append(paragraphProperties);

        return paragraph;
    }

    [HttpGet("Init")]
    public IActionResult Init()
    {
        return Ok("Init");
    }
}