using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace StatementConstructors {
   public partial class Program {
      private static void MassageInput(ref string pInput) {
         #region Mutually exclusive words
         if (pInput.Contains("public") && pInput.Contains("private")) {
            MessageBox.Show(string.Format("\"public\" and \"private\" are mutually exclusive. You said:{0}{1}", Environment.NewLine, pInput),
               "INPUT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (pInput.Contains("internal") && pInput.Contains("external")) {
            MessageBox.Show(string.Format("\"internal\" and \"extern\" (\"external\") are mutually exclusive. You said:{0}{1}", Environment.NewLine, pInput),
               "INPUT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         #endregion
         if (pInput == "format line")
            pInput = "normalize line";
         if (pInput.Contains("#"))
            pInput = StringReplaceWord(pInput, "#", " pound ");
         if (StringContainsWord(pInput, "inject")) {
            pInput = StringReplaceWord(pInput, "inject", string.Empty);
            injection = true;
         }
         else if (StringContainsWord(pInput, "injection")) {
            pInput = StringReplaceWord(pInput, "injection", string.Empty);
            injection = true;
         }
         if (StringContainsWord(pInput, "can"))
            pInput = StringReplaceWord(pInput, "can", "constructor");
         if (StringContainsWord(pInput, "come pound"))
            pInput = StringReplaceWord(pInput, "come pound", "compound");
         if (StringContainsWord(pInput, "exclamation mark"))
            pInput = StringReplaceWord(pInput, "exclamation mark", "!");
         if (StringContainsWord(pInput, "l"))
            pInput = StringReplaceWord(pInput, "l", "else");
         if (StringContainsWord(pInput, "abbreviate rectangle"))
            pInput = StringReplaceWord(pInput, "abbreviate rectangle", "RECT");
         if (StringContainsWord(pInput, "abbreviate"))
            pInput = StringReplaceWord(pInput, "abbreviate", string.Empty);
         if (StringContainsWord(pInput, "scroll bar"))
            pInput = StringReplaceWord(pInput, "scroll bar", "scrollbar");
         if (StringContainsWord(pInput, "^"))
            pInput = StringReplaceWord(pInput, "^", "caret");
         if (StringContainsWord(pInput, "carrot"))
            pInput = StringReplaceWord(pInput, "carrot", "caret");
         if (StringContainsWord(pInput, "bite"))
            pInput = StringReplaceWord(pInput, "bite", "byte");
         if (StringContainsWord(pInput, "short byte"))
            pInput = StringReplaceWord(pInput, "short byte", "shortbyte");
         if (StringContainsWord(pInput, "struct"))
            pInput = StringReplaceWord(pInput, "struct", "structure");
         if (StringContainsWord(pInput, "struck"))
            pInput = StringReplaceWord(pInput, "struck", "structure");
         if (StringContainsWord(pInput, "noel"))
            pInput = StringReplaceWord(pInput, "noel", "null");
         if (StringContainsWord(pInput, "no"))
            pInput = StringReplaceWord(pInput, "no", "null");
         if (StringContainsWord(pInput, "method"))
            pInput = StringReplaceWord(pInput, "method", "function");
         if (StringContainsWord(pInput, "variable"))
            pInput = StringReplaceWord(pInput, "variable", "var");
         if (StringContainsWord(pInput, "cap"))
            pInput = StringReplaceWord(pInput, "cap", "caps");
         if (StringContainsWord(pInput, "oar"))
            pInput = StringReplaceWord(pInput, "oar", "or");
         if (StringContainsWord(pInput, "ore"))
            pInput = StringReplaceWord(pInput, "ore", "or");
         if (StringContainsWord(pInput, "avoid"))
            pInput = StringReplaceWord(pInput, "avoid", "void");
         if (StringContainsWord(pInput, "lloyd"))
            pInput = StringReplaceWord(pInput, "lloyd", "void");
         if (StringContainsWord(pInput, "knot"))
            pInput = StringReplaceWord(pInput, "knot", "not");
         if (StringContainsWord(pInput, "not while"))
            pInput = StringReplaceWord(pInput, "not while", "while not");
         if (StringContainsWord(pInput, "external"))
            pInput = StringReplaceWord(pInput, "external", "extern");
         if (StringContainsWord(pInput, "e numb"))
            pInput = StringReplaceWord(pInput, "e numb", "enumerate");
         if (StringContainsWord(pInput, "enum"))
            pInput = StringReplaceWord(pInput, "enum", "enumerate");
         if (StringContainsWord(pInput, "enumerator"))
            pInput = StringReplaceWord(pInput, "enumerator", "enumerate");
         if (StringContainsWord(pInput, "private protected"))
            pInput = StringReplaceWord(pInput, "private protected", "privateProtected");
         if (StringContainsWord(pInput, "protected internal"))
            pInput = StringReplaceWord(pInput, "protected internal", "protectedInternal");
         if (StringContainsWord(pInput, "function key"))
            pInput = StringReplaceWord(pInput, "function key", "f");
         if (StringContainsWord(pInput, "f 1"))
            pInput = StringReplaceWord(pInput, "f 1", "fkey1");
         if (StringContainsWord(pInput, "f 2"))
            pInput = StringReplaceWord(pInput, "f 2", "fkey2");
         if (StringContainsWord(pInput, "f 3"))
            pInput = StringReplaceWord(pInput, "f 3", "fkey3");
         if (StringContainsWord(pInput, "f 4"))
            pInput = StringReplaceWord(pInput, "f 4", "fkey4");
         if (StringContainsWord(pInput, "f 5"))
            pInput = StringReplaceWord(pInput, "f 5", "fkey5");
         if (StringContainsWord(pInput, "f 6"))
            pInput = StringReplaceWord(pInput, "f 6", "fkey6");
         if (StringContainsWord(pInput, "f 7"))
            pInput = StringReplaceWord(pInput, "f 7", "fkey7");
         if (StringContainsWord(pInput, "f 8"))
            pInput = StringReplaceWord(pInput, "f 8", "fkey8");
         if (StringContainsWord(pInput, "f 9"))
            pInput = StringReplaceWord(pInput, "f 9", "fkey9");
         if (StringContainsWord(pInput, "f 10"))
            pInput = StringReplaceWord(pInput, "f 10", "fkey10");
         if (StringContainsWord(pInput, "f 11"))
            pInput = StringReplaceWord(pInput, "f 11", "fkey11");
         if (StringContainsWord(pInput, "f 12"))
            pInput = StringReplaceWord(pInput, "f 12", "fkey12");
         if (StringContainsWord(pInput, "f 13"))
            pInput = StringReplaceWord(pInput, "f 13", "fkey13");
         if (StringContainsWord(pInput, "f 14"))
            pInput = StringReplaceWord(pInput, "f 14", "fkey14");
         if (StringContainsWord(pInput, "f 15"))
            pInput = StringReplaceWord(pInput, "f 15", "fkey15");
         if (StringContainsWord(pInput, "f 16"))
            pInput = StringReplaceWord(pInput, "f 16", "fkey16");
         if (StringContainsWord(pInput, "f 17"))
            pInput = StringReplaceWord(pInput, "f 17", "fkey17");
         if (StringContainsWord(pInput, "f 18"))
            pInput = StringReplaceWord(pInput, "f 18", "fkey18");
         if (StringContainsWord(pInput, "f 19"))
            pInput = StringReplaceWord(pInput, "f 19", "fkey19");
         if (StringContainsWord(pInput, "f 20"))
            pInput = StringReplaceWord(pInput, "f 20", "fkey20");
         if (StringContainsWord(pInput, "f 21"))
            pInput = StringReplaceWord(pInput, "f 21", "fkey21");
         if (StringContainsWord(pInput, "f 22"))
            pInput = StringReplaceWord(pInput, "f 22", "fkey22");
         if (StringContainsWord(pInput, "f 23"))
            pInput = StringReplaceWord(pInput, "f 23", "fkey23");
         if (StringContainsWord(pInput, "f 24"))
            pInput = StringReplaceWord(pInput, "f 24", "fkey24");

         if (StringContainsWord(pInput, "f one"))
            pInput = StringReplaceWord(pInput, "f one", "fkey1");
         if (StringContainsWord(pInput, "f two"))
            pInput = StringReplaceWord(pInput, "f two", "fkey2");
         if (StringContainsWord(pInput, "f to"))
            pInput = StringReplaceWord(pInput, "f to", "fkey2");
         if (StringContainsWord(pInput, "f too"))
            pInput = StringReplaceWord(pInput, "f too", "fkey2");
         if (StringContainsWord(pInput, "f three"))
            pInput = StringReplaceWord(pInput, "f three", "fkey3");
         if (StringContainsWord(pInput, "f four"))
            pInput = StringReplaceWord(pInput, "f four", "fkey4");
         if (StringContainsWord(pInput, "f fore"))
            pInput = StringReplaceWord(pInput, "f fore", "fkey4");
         if (StringContainsWord(pInput, "f for"))
            pInput = StringReplaceWord(pInput, "f for", "fkey4");
         if (StringContainsWord(pInput, "f five"))
            pInput = StringReplaceWord(pInput, "f five", "fkey5");
         if (StringContainsWord(pInput, "f six"))
            pInput = StringReplaceWord(pInput, "f six", "fkey6");
         if (StringContainsWord(pInput, "f sax"))
            pInput = StringReplaceWord(pInput, "f sax", "fkey6");
         if (StringContainsWord(pInput, "f sex"))
            pInput = StringReplaceWord(pInput, "f sex", "fkey6");
         if (StringContainsWord(pInput, "f seven"))
            pInput = StringReplaceWord(pInput, "f seven", "fkey7");
         if (StringContainsWord(pInput, "f eight"))
            pInput = StringReplaceWord(pInput, "f eight", "fkey8");
         if (StringContainsWord(pInput, "f ate"))
            pInput = StringReplaceWord(pInput, "f ate", "fkey8");
         if (StringContainsWord(pInput, "f nine"))
            pInput = StringReplaceWord(pInput, "f nine", "fkey9");
         if (StringContainsWord(pInput, "f ten"))
            pInput = StringReplaceWord(pInput, "f ten", "fkey10");
         if (StringContainsWord(pInput, "f tin"))
            pInput = StringReplaceWord(pInput, "f tin", "fkey10");
         if (StringContainsWord(pInput, "f eleven"))
            pInput = StringReplaceWord(pInput, "f eleven", "fkey11");
         if (StringContainsWord(pInput, "f twelve"))
            pInput = StringReplaceWord(pInput, "f twelve", "fkey12");
         if (StringContainsWord(pInput, "f thirteen"))
            pInput = StringReplaceWord(pInput, "f thirteen", "fkey13");
         if (StringContainsWord(pInput, "f fourteen"))
            pInput = StringReplaceWord(pInput, "f fourteen", "fkey14");
         if (StringContainsWord(pInput, "f fifteen"))
            pInput = StringReplaceWord(pInput, "f fifteen", "fkey15");
         if (StringContainsWord(pInput, "f sixteen"))
            pInput = StringReplaceWord(pInput, "f sixteen", "fkey16");
         if (StringContainsWord(pInput, "f seventeen"))
            pInput = StringReplaceWord(pInput, "f seventeen", "fkey17");
         if (StringContainsWord(pInput, "f eighteen"))
            pInput = StringReplaceWord(pInput, "f eighteen", "fkey18");
         if (StringContainsWord(pInput, "f nineteen"))
            pInput = StringReplaceWord(pInput, "f nineteen", "fkey19");
         if (StringContainsWord(pInput, "f twenty"))
            pInput = StringReplaceWord(pInput, "f twenty", "fkey20");
         if (StringContainsWord(pInput, "f twenty-one"))
            pInput = StringReplaceWord(pInput, "f twenty-one", "fkey21");
         if (StringContainsWord(pInput, "f twenty-two"))
            pInput = StringReplaceWord(pInput, "f twenty-two", "fkey22");
         if (StringContainsWord(pInput, "f twenty-three"))
            pInput = StringReplaceWord(pInput, "f twenty-three", "fkey23");
         if (StringContainsWord(pInput, "f twenty-four"))
            pInput = StringReplaceWord(pInput, "f twenty-four", "fkey24");
         if (StringContainsWord(pInput, "zero"))
            pInput = StringReplaceWord(pInput, "zero", "0");
         if (StringContainsWord(pInput, "2"))
            pInput = StringReplaceWord(pInput, "2", "to");
         if (StringContainsWord(pInput, "two"))
            pInput = StringReplaceWord(pInput, "two", "to");
         if (StringContainsWord(pInput, "too"))
            pInput = StringReplaceWord(pInput, "too", "to");
         if (StringContainsWord(pInput, "write"))
            pInput = StringReplaceWord(pInput, "write", "right");
         if (StringContainsWord(pInput, "wright"))
            pInput = StringReplaceWord(pInput, "wright", "right");
         if (StringContainsWord(pInput, "parens"))
            pInput = StringReplaceWord(pInput, "parens", "paren");
         if (StringContainsWord(pInput, "parentheses"))
            pInput = StringReplaceWord(pInput, "parentheses", "paren");
         if (StringContainsWord(pInput, "parents"))
            pInput = StringReplaceWord(pInput, "parents", "paren");
         if (StringContainsWord(pInput, "falls"))
            pInput = StringReplaceWord(pInput, "falls", "false");
         if (StringContainsWord(pInput, "fall"))
            pInput = StringReplaceWord(pInput, "fall", "false");
         if (StringContainsWord(pInput, "4"))
            pInput = StringReplaceWord(pInput, "4", "for");
         if (StringContainsWord(pInput, "four"))
            pInput = StringReplaceWord(pInput, "four", "for");
         if (StringContainsWord(pInput, "if simple else compound"))
            pInput = StringReplaceWord(pInput, "if simple else compound", "ifsimple elsecompound");
         if (StringContainsWord(pInput, "if compound else simple"))
            pInput = StringReplaceWord(pInput, "if compound else simple", "ifcompound elsesimple");
         if (StringContainsWord(pInput, "if not simple else compound"))
            pInput = StringReplaceWord(pInput, "if not simple else compound", "ifnotsimple elsecompound");
         if (StringContainsWord(pInput, "if not compound else simple"))
            pInput = StringReplaceWord(pInput, "if not compound else simple", "ifnotcompound elsesimple");
         if (StringContainsWord(pInput, "simple if"))
            pInput = StringReplaceWord(pInput, "simple if", "if simple");
         if (StringContainsWord(pInput, "simple if else"))
            pInput = StringReplaceWord(pInput, "simple if else", "if else simple");
         if (StringContainsWord(pInput, "simple for"))
            pInput = StringReplaceWord(pInput, "simple for", "for simple");
         if (StringContainsWord(pInput, "simple integer for"))
            pInput = StringReplaceWord(pInput, "simple integer for", "for simple integer");
         if (StringContainsWord(pInput, "for integer simple"))
            pInput = StringReplaceWord(pInput, "for integer simple", "for simple integer");
         if (StringContainsWord(pInput, "this simple"))
            pInput = StringReplaceWord(pInput, "this simple", "simple this");
         if (StringContainsWord(pInput, "simple else"))
            pInput = StringReplaceWord(pInput, "simple else", "else simple");
         if (StringContainsWord(pInput, "this compound"))
            pInput = StringReplaceWord(pInput, "this compound", "compound this");
         if (StringContainsWord(pInput, "you"))
            pInput = StringReplaceWord(pInput, "you", "unsigned");
         if (StringContainsWord(pInput, "u"))
            pInput = StringReplaceWord(pInput, "u", "unsigned");
         if (StringContainsWord(pInput, "int"))
            pInput = StringReplaceWord(pInput, "int", "integer");
         if (StringContainsWord(pInput, "uint"))
            pInput = StringReplaceWord(pInput, "uint", "unsigned integer");
         if (StringContainsWord(pInput, "integer 16"))
            pInput = StringReplaceWord(pInput, "integer 16", "int16");
         if (StringContainsWord(pInput, "integer 32"))
            pInput = StringReplaceWord(pInput, "integer 32", "int32");
         if (StringContainsWord(pInput, "integer 64"))
            pInput = StringReplaceWord(pInput, "integer 64", "int64");
         if (StringContainsWord(pInput, "unsigned integer 16"))
            pInput = StringReplaceWord(pInput, "unsigned integer 16", "uint16");
         if (StringContainsWord(pInput, "unsigned integer 32"))
            pInput = StringReplaceWord(pInput, "unsigned integer 32", "uint32");
         if (StringContainsWord(pInput, "unsigned integer 64"))
            pInput = StringReplaceWord(pInput, "unsigned integer 64", "uint64");
         if (StringContainsWord(pInput, "unsigned long"))
            pInput = StringReplaceWord(pInput, "unsigned long", "ulong");
         if (StringContainsWord(pInput, "unsigned short"))
            pInput = StringReplaceWord(pInput, "unsigned short", "ushort");
         if (StringContainsWord(pInput, "due"))
            pInput = StringReplaceWord(pInput, "due", "do");
         if (StringContainsWord(pInput, "weight"))
            pInput = StringReplaceWord(pInput, "weight", "wait");
         if (StringContainsWord(pInput, " semicolon"))
            pInput = StringReplaceWord(pInput, " semicolon", ";");
         if (StringContainsWord(pInput, "boolean"))
            pInput = StringReplaceWord(pInput, "boolean", "bool");
         if (StringContainsWord(pInput, "unsigned"))
            pInput = StringReplaceWord(pInput, "u ", "unsigned ");
         if (StringContainsWord(pInput, "read-only"))
            pInput = StringReplaceWord(pInput, "read-only", "readonly");
         if (StringContainsWord(pInput, "constance"))
            pInput = StringReplaceWord(pInput, "constance", "constant");
         if (StringContainsWord(pInput, "const"))
            pInput = StringReplaceWord(pInput, "const", "constant");
         if (StringContainsWord(pInput, "ref "))
            pInput = StringReplaceWord(pInput, "ref ", "reference ");
         if (StringContainsWord(pInput, "message box"))
            pInput = StringReplaceWord(pInput, "message box", "messagebox");
         if (StringContainsWord(pInput, "="))
            pInput = StringReplaceWord(pInput, "=", "equals");
         if (StringContainsWord(pInput, "equal"))
            pInput = StringReplaceWord(pInput, "equal", "equals");
         if (StringContainsWord(pInput, "is equals to"))
            pInput = StringReplaceWord(pInput, "is equals to", "equals");
         if (StringContainsWord(pInput, "character"))
            pInput = StringReplaceWord(pInput, "character", "char");
         if (StringContainsWord(pInput, "equals new"))
            pInput = StringReplaceWord(pInput, "equals new", "equalsnew");
         if (StringContainsWord(pInput, "integer pointer"))
            pInput = StringReplaceWord(pInput, "integer pointer", "integerpointer");
         if (StringContainsWord(pInput, "capitals"))
            pInput = StringReplaceWord(pInput, "capitals", "pascal");
         if (StringContainsWord(pInput, "capital"))
            pInput = StringReplaceWord(pInput, "capital", "pascal");
         pInput = CompressWhiteSpace(pInput);
         pInput = pInput.Replace("\t", " ");
      }

      private static string RemoveLeadingSpaces(string pName) {
         string returnString = pName;
         char[] charsToTrim = { ' ', '\t' };
         returnString = returnString.TrimStart(charsToTrim);
         return returnString;
      }

      private static string RemoveTrailingSpaces(string pName) {
         string returnString = pName;
         char[] charsToTrim = { ' ', '\t' };
         returnString = returnString.TrimEnd(charsToTrim);
         return returnString;
      }

      private static string CompressWhiteSpace(string pName) {
         //compresses all duplicate identical white spaces into a single one 
         //NOTE: the string is NOT trimmed of leading nor trailing spaces
         /*A string that looks like:
               " Word<space><space>another word<tab><tab> "
           Becomes:                          
               " Word<space>another word<tab> "
           But                       
               "Word<space><tab>another word<tab><tab>"
           Becomes:                          
               "Word<space><tab>another word<tab>"
         */
         int nameLength = pName.Length,
             index = 0,
             i = 0;
         char[] nameAsCharacterArray = pName.ToCharArray();
         bool skip = false;
         char individualCharacter;
         for (; i < nameLength; i++) {
            individualCharacter = nameAsCharacterArray[i];
            switch (individualCharacter) {
               case '\u0020':
               case '\u00A0':
               case '\u1680':
               case '\u2000':
               case '\u2001':
               case '\u2002':
               case '\u2003':
               case '\u2004':
               case '\u2005':
               case '\u2006':
               case '\u2007':
               case '\u2008':
               case '\u2009':
               case '\u200A':
               case '\u202F':
               case '\u205F':
               case '\u3000':
               case '\u2028':
               case '\u2029':
               case '\u0009':
               case '\u000A':
               case '\u000B':
               case '\u000C':
               case '\u000D':
               case '\u0085':
                  if (skip) continue;
                  nameAsCharacterArray[index++] = individualCharacter;
                  skip = true;
                  continue;
               default:
                  skip = false;
                  nameAsCharacterArray[index++] = individualCharacter;
                  continue;
            }
         }
         string returnString = new string(nameAsCharacterArray, 0, index);
         if (returnString.Contains("  ")) {
            do {
               returnString = returnString.Replace("  ", " ");
            }
            while (returnString.Contains("  "));
         }
         if (returnString.Contains("( "))
            returnString = returnString.Replace("( ", "(");
         if (returnString.Contains(" ;"))
            returnString = returnString.Replace(" ;", ";");
         return returnString;
      }

      private static string CapitalizeAllWords(string pName) {
         char[] delimiters = new char[] { ' ', '“', '‘', '(', '[', '\t', '¡', '¿' };
         string characterToChange = "";
         string precedingCharacter = "";
         int length = pName.Length;
         char[] resultString = pName.ToCharArray();

         for (int i = 0; i < length; i++) {
            characterToChange = pName.Substring(i, 1);
            if (i == 0) {
               characterToChange = characterToChange.ToUpper();
               resultString[i] = Char.Parse(characterToChange);
            }
            else {
               precedingCharacter = pName.Substring(i - 1, 1);
               foreach (char delimiter in delimiters) {
                  if (delimiter == Char.Parse(precedingCharacter))
                     characterToChange = characterToChange.ToUpper();
               }
               resultString[i] = Char.Parse(characterToChange);
            }
         }
         string returnString = new string(resultString);
         char[] charsToTrim = { ' ', '\t' };
         returnString = returnString.Trim(charsToTrim);
         return returnString;
      }

      private static bool StringContainsWord(string pString, string pWord) {
         string pattern = @"\b" + Regex.Escape(pWord) + @"\b";

         return Regex.Match(pString, pattern, RegexOptions.IgnoreCase).Success;
      }

      private static string StringReplaceWord(string pString, string pWord, string pReplacement) {
         string pattern = @"\b" + Regex.Escape(pWord) + @"\b";

         return Regex.Replace(pString, pattern, pReplacement);
      }

      private static void ForceLeadingSpace() {
         if (proceededByCharacter && !injection)
            SendKeys.SendWait(" ");
      }

      private static void GetLeading() {
         string firstLeading = string.Empty, holdClipboard = Clipboard.GetText();

         Clipboard.Clear();
         SendKeys.SendWait("+{LEFT}");
         SendKeys.SendWait("^c");
         firstLeading = Clipboard.GetText();
         SendKeys.SendWait("{RIGHT}");
         if (firstLeading.Contains(Environment.NewLine) || string.IsNullOrEmpty(firstLeading)) {
            SendKeys.SendWait("{UP}{END}{DOWN}");
            Clipboard.SetText(holdClipboard);
            return;//accept the defaults - at the beginning of a line
         }
         if (string.IsNullOrWhiteSpace(firstLeading)) //not immediately preceded by a character
            proceededByCharacter = false;
         else if ((firstLeading == "{") || (firstLeading == ";") || (firstLeading == "}") || (firstLeading == ")")) {
            proceededByCharacter = true;//Add a space after the statement termination
            SendKeys.SendWait("{END}");
            if (!injection) {
               proceededByCharacter = false;//Override the previous true
               SendKeys.SendWait("{ENTER}");
            }
         }
         else
            proceededByCharacter = true;
         Clipboard.SetText(holdClipboard);
      }
   }
}
