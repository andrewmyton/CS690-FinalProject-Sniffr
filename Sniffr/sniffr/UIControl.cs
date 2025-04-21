namespace sniffr;
using Spectre.Console;

public class UIControl{

public string DisplayMenu(string[] option){
    var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(option));
            
    return selection;
}



}