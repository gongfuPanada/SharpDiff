<Query Kind="Program">
  <Reference Relative="..\DiffLib\bin\Debug\DiffLib.dll">C:\dev\vs.net\difflib\DiffLib\bin\Debug\DiffLib.dll</Reference>
  <Namespace>DiffLib</Namespace>
</Query>

const string text1 = "This is a test of the diff implementation, with some text that is deleted.";
const string text2 = "This is another test of the same implementation, with some more text.";

void Main()
{
    DumpDiff(new Diff<char>(text1, text2));
}

static void DumpDiff(IEnumerable<DiffChange> changes)
{
    var html = new StringBuilder();
    int i1 = 0;
    int i2 = 0;
    foreach (var change in changes)
    {
        if (change.Equal)
            html.Append(text1.Substring(i1, change.Length1));
        else
        {
            html.Append("<span style='background-color: #ffcccc; text-decoration: line-through;'>" + text1.Substring(i1, change.Length1) + "</span>");
            html.Append("<span style='background-color: #ccffcc;'>" + text2.Substring(i2, change.Length2) + "</span>");
        }
        
        i1 += change.Length1;
        i2 += change.Length2;
    }
    Util.RawHtml(html.ToString()).Dump();
}