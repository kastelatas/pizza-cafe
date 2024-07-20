using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Paragraph = DocumentFormat.OpenXml.Drawing.Paragraph;
using Run = DocumentFormat.OpenXml.Drawing.Run;
using RunProperties = DocumentFormat.OpenXml.Drawing.RunProperties;
using TableCell = DocumentFormat.OpenXml.Drawing.TableCell;
using TableCellProperties = DocumentFormat.OpenXml.Drawing.TableCellProperties;
using Text = DocumentFormat.OpenXml.Drawing.Text;

namespace pizza_cafe.Server.Services;

public class WordService
{
    public TableCell CreateTableCell(string text, string width, bool isBold, int fontSize)
    {
        TableCell cell = new TableCell();
        Paragraph paragraph = new Paragraph();
        Run run = new Run(new Text(text));

        // Настройка стиля текста в ячейке
        RunProperties runProperties = new RunProperties();

        // Начертание текста
        if (isBold)
            runProperties.Bold = new BooleanValue(true);

        // Размер шрифта
        runProperties.FontSize = new Int32Value(fontSize) ;

        run.PrependChild(runProperties);
        paragraph.Append(run);
        cell.Append(paragraph);

        // Настройка ширины ячейки
        cell.Append(new TableCellProperties(new TableCellWidth()
        {
            Type = TableWidthUnitValues.Dxa,
            Width = width
        }));

        return cell;
    }
}