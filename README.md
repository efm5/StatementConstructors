# StatementConstructors
StatementConstructor is designed to be used with Dragon® (or other speech recognition software which can trigger an open-ended dictation command) to insert code snippets. 

In Dragon®’s scripting language the open-ended dictation command might look something like:
Puff <dictation>
where the first word is the trigger word - a word which would rarely be used at the beginning of a sentence and is easy to utter. The actual command itself would consist of a single statement:
Sub Main
   ShellExecute "Z:\StatementConstrucor\StatementConstructors.exe" & " " & ListVar1, 7
End Sub
The exact location of the executable would depend on where it was stored on your computer.

The application has a special mode: "What can I say", so, if you say:
"puff what can I say"
(assuming your trigger word is "puff") the "What Can I Say" dialog opens displaying these directions and a lot of the things that you can say. The "directions" TextBox has a context menu with three items:
Read these directions in your favorite text editor… Ctrl+R
Copy all of the dictionary utterances to the clipboard Ctrl+C 
Font selector… Ctrl+F
they have accelerator keys:
"Read these directions in your favorite text editor…": Alt+R
"Copy all of the dictionary utterances to the clipboard": Alt+C
"Font selector…": Alt+F

When compiled to do so, it also has a second special mode: "exercise all the methods", so, if you say:
"puff exercise all the methods"
(and the appropriate section of the code has been un-commented), all of the SnippetMethods methods will be called in (approximate) alphabetical order. Beware, this will result in over two thousand lines being printed out so you probably want to do it with an empty Notepad window open. To re-establish this functionality you will need to remove the comment marks from two sections of code. The first is in Program.cs at or near line number 50; the other is in SnippetMethods.cs at or near line number 24.

There is another special mode: "normalize line". If you have Visual Studio set so that it formats a line on paste or when a semicolon is pressed, this command will select the line and let IntelliSense cleanup the formatting. If you dig into Visual Studio's keyboard shortcuts  (Tools> Options> Environment> Keyboard) you will find one which forces the entire document to reformat (Edit.FormatDocument). I have given this the keyboard shortcut: SHIFT + CONTROL + ALTERNATE + J (it's getting hard to find unused keyboard shortcuts in Visual Studio - I have become somewhat cavalier about eliminating default shortcuts for things I will never need). I have an application-specific Advanced Scripting command which triggers this shortcut.

There are three general kinds of statements which the application recognizes:
	1) Obscure words or phrases which cause Dragon® to stumble when uttered singly and/or out of context.
	2) Insertion of code snippets - a generic "for each" construction, a basic "if" construction etc.
	3) Construction of variable, class or other type names - you might wish to create a variable named "private bool someName", or "public static integer anotherName"; or a function or class named "SpecialName".

In the first case listed above you would say the trigger word (in this case "puff") followed by the problematical word or phrase. Here are some examples:
"puff break" which (because "break" always has a semicolon after it) yields: break;
"puff integer pointer zero" which yields:  IntPtr.Zero;
"puff structure" or "puff struct" or even "puff struck" all of which yield: struct 
For me, Dragon® absolutely refuses to recognize the word "null" (about half the time it gives "no" the rest of the time giving "Noel"). You may say "puff no", "puff Noel" or "puff null", all of which yield: null
Take a look at the file "MassageInput.cs" to see how similar homophones are handled, MassageInput(ref inputParameter) is the first step of handling an utterance (inputParameter).

In the second case listed above, inserting code snippets (which happens right after the input has been massaged), the utterance is tested to see if it exactly matches anything in the SnippetDictionary (see Dictionary.cs). If an exact match is found in the dictionary the appropriate SnippetMethods (see SnippetMethods.cs) method is exercised, sending the appropriate series of keypresses to the application which has focus.

Some of the SnippetDictionary entries have "this" as part of the utterance ("if this", "do while this" etc.). For these constructs, the textual content of the clipboard is pasted in the appropriate place ("if (clipboard)", "do { } while (clipboard)" etc.). If there is no text on the clipboard nothing will be pasted - no harm no foul. It is the user's responsibility to make sure that the textual content of the clipboard is appropriate.

The third case comes into play only if the second case fails to identify something in the dictionary. This is by far the most complicated section of the code. It parses the utterance looking for various keywords (variable types, accessibility types, function parameter modifiers and a few "special" cases: "equals new", "function", "class", "structure", and "enumerator". Based on this parsing it tries to craft a legal C, C++ or C# statement or partial statement. If there are words in the utterance which it does not recognize it uses those words to create a variable name which it places in the appropriate part of the statement. In doing this section of the parsing it looks for a few "special" words: "member"; "global"; "parameter"; "Pascal" (which is a pseudonym for "capital" and "capitals"); "snake" and "upper" (either singly or as a pair); and "camel". You may say things like:
"puff Pascal some name" and get: SomeName
"puff member some name": mSomeName
"puff global some name": gSomeName
"puff snake Pascal some name":  Some_Name
"puff snake Pascal member some name":  mSome_Name
"puff snake parameter some name":  pSome_name
"puff snake global some name":    gSome_name
"puff snake upper some name":  SOME_NAME
"puff upper some name":  UPPERSOMENAME
"puff camel some name":  someName
Note that in the case of the modifiers (member, global, parameter) the next letter is always capitalized.

You may also create complex variables (the exact order of the utterance is not important):
"puff integer private constant": const private int 
"puff static public integer": public static int
"puff public private" will display an error dialog because you may not have both public and private access types.

There are some special complex types that are created here (structures, functions, classes and enumerators):
"puff integer function some name":
int SomeName() {
}
"puff integer enumerator some name":
enum someName : int {
XXX = 0,
XXX1 = 1
}
"puff enumerator some name" (i.e. no type):
enum someName {
XXX = 0,
XXX1 = 1
}
"puff structure some name":
struct SomeName {
}
"puff class some name":
class  SomeName {
}
"puff method some name":
or "puff function some name":  
someName() {
}
"puff function integer some name":
int someName() {
}
"puff function integer some name static":
static int someName() {
}
Your editor should handle the indentation smartly. Some effort is made to ensure that multiple spaces are not inserted.

There are two insertion modes. The default is to insert a NewLine after a semicolon or a right (closing) curly brace, otherwise to insert a space after any recognizable non-whitespace character (I have not yet tested it with hard tabs). However, if the utterance contains "inject" or "injection" no space will be added in front of the construction based on the utterance.


New for version 1.0.0.4:
I fixed a bug involving the font in the "What Can I Say" dialog. Strings were being measured based on a immutable font not the Settings.Default.Font.

I made "internal" and "external" mutually exclusive. Just like "public" and "private" they may never be in the same statement.

I struggled trying to figure out how to replace selected text with the constructed output - I failed. If you have some text selected and you want to replace it you will have to say "press delete"Or your favorite equivalent.

There are a couple of new entries to the dictionary: "pound region", "end region", "size dot", "location dot", "not" or "exclamation mark" (logical not). Within the dictionary methods I noticed that in every place I had "else if" there was no space before the following opening parentheses - I added them.

You may now say: [trigger word, e.g. "puff"] followed by "pound region" and follow that with any utterance. The utterance will be parsed and made lowercase and the output will look something like:
#region a label for the region

You may now say: [trigger word, e.g. "puff"] followed by "camel case", "class case" or the equivalent "pascal case", "snake case", "pascal snake case" or the equivalent "snake pascal case", "upper case" or the equivalent "uppercase", "upper snake case" or the equivalent "snake upper case".
brownDog (camel case)
BrownDog (class or Pascal case)
brown_dog (snake case)
Brown_Dog (Pascal snake case)
BROWNDOG (upper case)
BROWN_DOG (upper snake case)

There is new a construction: for each [variable type] (e.g. "for each string", "for each float", "for each text box"). It tries to do the right thing with the variable type and the variable name:
foreach (string phrase in whatList ) {
}
foreach (float number in whatList ) {
}
foreach (TextBox textBox in whatList ) {
}
Since "string" is kind of special it uses the name "word". For numeric variable types it uses the generic name "number". For any other variable type it creates a Pascal-case type Followed by the same word with its initial character in lowercase.

There is a new special mode: "normalize line". If you have Visual Studio set so that it formats a line on paste or when a semicolon is pressed, this command will select the line and let IntelliSense cleanup the formatting.

SendKeys.SendWait() is known to have some timing issues. Microsoft® changed the default behavior a while back but left it possible for the developer to compile using the original behavior. There is a change which may be made in "App.config". I am including two versions: "App.config" and "App.bak.config". Look at the area around line number eleven to see the difference - try them both and see which works faster on your system.


New for version 1.0.0.5
I am now using the other "App.config", this one has the addition of:
    <appSettings>
        <add key="SendKeys" value="SendInput"/>
    </appSettings>
it seems to be quite a bit faster and, assuming it continues working well for me it will be the default.
