using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace StatementConstructors {
   public static class StringExtensions {
      public static string FirstCharToUpper(this string input) {
         switch (input) {
            case null: throw new ArgumentNullException(nameof(input));
            case "": return string.Empty;
            //case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
            default: return input.First().ToString().ToUpper() + input.Substring(1);
         }
      }

      public static string FirstCharToLower(this string input) {
         switch (input) {
            case null: throw new ArgumentNullException(nameof(input));
            case "": return string.Empty;
            //case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
            default: return input.First().ToString().ToLower() + input.Substring(1);
         }
      }
   }

   public partial class Program {
      private static void BuildAndSendVariables(string pInput) {
         string normalizedString = string.Empty, trailingName = pInput, variableType = string.Empty;
         int accessibles = 0, variables = 0, modifier = 0, lengthOfType = 0, construction = 0, capitalize = 0, prefixes = 0;
         bool
            //Variable types:
            bytes = false, sbytes = false, objects = false, vars = false, voids = false, bools = false, characters = false, doubles = false,
            floats = false, integers = false, int16s = false, int32s = false, int64s = false, unsigneds = false, uints = false,
            uint16s = false, uint32s = false, uint64s = false, longs = false, ulongs = false, shorts = false, ushorts = false,
            //Construction:
            lists = false, strings = false, enumerators = false, functions = false, structures = false, classes = false, partials = false,
            equalsNews = false,
            //Accessibility types:
            virtuals = false, overrides = false, constants = false, statics = false, privates = false, publics = false, protecteds = false,
            internals = false, protectedInternals = false, privateProtecteds = false, externals = false, readOnlys = false,
            abstracts = false, asyncs = false, events = false, sealeds = false, unsafes = false, volatiles = false,
            //Case modifiers:
            cases = false, camelCase = false, snakeCase = false, pascalSnakeCase = false, upperCase = false,
            snakes = false, uppers = false, camels = true,//camels is the default
            upperSnakeCase = false, forEach = false,
            //Parameter modifiers:
            references = false, outs = false, ins = false, arrays = false, members = false, globals = false, parameters = false;

         if (pInput.StartsWith("pound region")) {
            SendKeys.SendWait("#region");
            SendKeys.SendWait(pInput.Replace("pound region", string.Empty));
            return;
         }
         if (StringContainsWord(pInput, "internal") && (StringContainsWord(pInput, "private") || StringContainsWord(pInput, "public"))) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain both \"internal\" and either of \"private\" or \"public\". You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (pInput.StartsWith("for each")) {
            forEach = true;
            camels = false;
         }
         else if (pInput.StartsWith("camel case")) {
            cases = true;
            camelCase = true;
         }
         else if ((pInput.StartsWith("class case")) || (pInput.StartsWith("pascal case"))) {
            cases = true;
            camels = false;
         }
         else if (pInput.StartsWith("snake case")) {
            cases = true;
            snakeCase = true;
         }
         else if ((pInput.StartsWith("pascal snake case")) || (pInput.StartsWith("snake pascal case"))) {
            cases = true;
            pascalSnakeCase = true;
            camels = false;
         }
         else if ((pInput.StartsWith("upper case")) || (pInput.StartsWith("uppercase"))) {
            cases = true;
            upperCase = true;
            camels = false;
         }
         else if ((pInput.StartsWith("upper snake case")) || (pInput.StartsWith("snake upper case"))) {
            cases = true;
            upperSnakeCase = true;
            camels = false;
         }
         if (StringContainsWord(pInput, "equalsnew")) {
            equalsNews = true;
         }
         if (StringContainsWord(pInput, "partial")) {
            partials = true;
            construction++;
         }
         if (StringContainsWord(pInput, "function")) {
            functions = true;
            construction++;
         }
         if (StringContainsWord(pInput, "structure")) {
            structures = true;
            construction++;
         }
         if (StringContainsWord(pInput, "class")) {
            classes = true;
            construction++;
         }
         if (StringContainsWord(pInput, "object")) {
            objects = true;
            variables++;
         }
         if (StringContainsWord(pInput, "var")) {
            vars = true;
            variables++;
         }
         if (StringContainsWord(pInput, "void")) {
            voids = true;
            variables++;
         }
         if (StringContainsWord(pInput, "byte")) {
            bytes = true;
            variables++;
         }
         if (StringContainsWord(pInput, "shortbyte")) {
            sbytes = true;
            variables++;
         }
         if (StringContainsWord(pInput, "bool")) {
            bools = true;
            variables++;
         }
         if (StringContainsWord(pInput, "char")) {
            characters = true;
            variables++;
         }
         if (StringContainsWord(pInput, "double")) {
            doubles = true;
            variables++;
         }
         if (StringContainsWord(pInput, "float")) {
            floats = true;
            variables++;
         }
         if (StringContainsWord(pInput, "integer")) {
            integers = true;
            variables++;
         }
         if (StringContainsWord(pInput, "int16")) {
            int16s = true;
            variables++;
         }
         if (StringContainsWord(pInput, "int32")) {
            int32s = true;
            variables++;
         }
         if (StringContainsWord(pInput, "int64")) {
            int64s = true;
            variables++;
         }
         if (StringContainsWord(pInput, "unsigned")) {
            unsigneds = true;
         }
         if (StringContainsWord(pInput, "uint16")) {
            uint16s = true;
            variables++;
         }
         if (StringContainsWord(pInput, "uint32")) {
            uint32s = true;
            variables++;
         }
         if (StringContainsWord(pInput, "uint64")) {
            uint64s = true;
            variables++;
         }
         if (StringContainsWord(pInput, "long")) {
            longs = true;
            variables++;
         }
         if (StringContainsWord(pInput, "ulong")) {
            longs = true;
            unsigneds = true;
            variables++;
         }
         if (StringContainsWord(pInput, "short")) {
            shorts = true;
            variables++;
         }
         if (StringContainsWord(pInput, "ushort")) {
            shorts = true;
            unsigneds = true;
            variables++;
         }
         if (StringContainsWord(pInput, "list")) {
            lists = true;
         }
         if (StringContainsWord(pInput, "enumerate")) {
            enumerators = true;
         }
         if (StringContainsWord(pInput, "string")) {
            strings = true;
            variables++;
         }
         if (StringContainsWord(pInput, "override")) {
            overrides = true;
         }
         if (StringContainsWord(pInput, "virtual")) {
            virtuals = true;
         }
         if (StringContainsWord(pInput, "constant")) {
            constants = true;
         }
         if (StringContainsWord(pInput, "static")) {
            statics = true;
         }
         if (StringContainsWord(pInput, "private")) {
            privates = true;
            accessibles++;
         }
         if (StringContainsWord(pInput, "public")) {
            publics = true;
            accessibles++;
         }
         if (StringContainsWord(pInput, "protected")) {
            protecteds = true;
            accessibles++;
         }
         if (StringContainsWord(pInput, "internal")) {
            internals = true;
            accessibles++;
         }
         if (StringContainsWord(pInput, "protectedInternal")) {
            protectedInternals = true;
            accessibles++;
         }
         if (StringContainsWord(pInput, "privateProtected")) {
            privateProtecteds = true;
            accessibles++;
         }
         if (StringContainsWord(pInput, "extern")) {
            externals = true;
            accessibles++;
         }
         if (StringContainsWord(pInput, "readonly")) {
            readOnlys = true;
         }
         if (StringContainsWord(pInput, "abstract")) {
            abstracts = true;
            variables++;
         }
         if (StringContainsWord(pInput, "async")) {
            asyncs = true;
            variables++;
         }
         if (StringContainsWord(pInput, "event")) {
            events = true;
            variables++;
         }
         if (StringContainsWord(pInput, "sealed")) {
            sealeds = true;
            variables++;
         }
         if (StringContainsWord(pInput, "unsafe")) {
            unsafes = true;
            variables++;
         }
         if (StringContainsWord(pInput, "volatile")) {
            volatiles = true;
            variables++;
         }
         if (StringContainsWord(pInput, "reference")) {
            references = true;
            modifier++;
         }
         if (StringContainsWord(pInput, "out")) {
            outs = true;
            modifier++;
         }
         if (StringContainsWord(pInput, "in")) {
            ins = true;
            modifier++;
         }
         if (StringContainsWord(pInput, "array"))
            arrays = true;
         if (StringContainsWord(pInput, "member")) {
            members = true;
            prefixes++;
         }
         if (StringContainsWord(pInput, "global")){
            globals = true;
            prefixes++;
         }
         if ((StringContainsWord(pInput, "parameter")) && !cases) {
            parameters = true;
            prefixes++;
         }
         if ((StringContainsWord(pInput, "pascal")) && !cases) {
            capitalize++;
            camels = false;
         }
         if ((StringContainsWord(pInput, "snake")) && !cases)
            snakes = true;
         if ((StringContainsWord(pInput, "upper")) && !cases) {
            uppers = true;
            capitalize++;
            camels = false;
         }
         if ((StringContainsWord(pInput, "camel")) && !cases) {
            capitalize++;
         }
         if (StringContainsWord(pInput, "partial") && !classes) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain \"partial\" unless it also contains \"class\". You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (cases && ((variables > 0) || (modifier > 0) || equalsNews || (construction > 1) || (accessibles > 1) ||
            arrays || structures || lists || enumerators)) {
            MessageBox.Show(string.Format(
               "Your utterance may not start with:{0}" +
               "\"camel\", \"class\", \"upper\", \"snake\", \"pascal\",{0}" +
               "\"pascal snake\" or snake pascal\", and \"upper snake\" or snake upper\"{0}" +
               "followed by \"case\" AND have variable types, modifiers, accessibility restrictions," +
               "or the words \"list\", \" array\", \"structure\" nor \"struct\", and \"enumerator\" nor \"enum\". You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (classes && (variables  > 0 )) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain \"class\" and any type of variable. You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (classes && (modifier > 0)) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain \"class\" and any modifier. You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (classes && equalsNews) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain \"class\" and \"equal(s) new\". You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (variables > 1) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain more than one variable type unless one of those is of type list. You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (capitalize > 1) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain more than one of \"Pascal\", \"upper\" or \"camel\". You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (construction > 1) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain more than one construction type. You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (accessibles > 1) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain more than one accessibility type. You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (modifier > 1) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain more than one modifier type. You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (prefixes > 1) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain more than one prefix. You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if ((accessibles > 0) && (modifier > 0)) {
            MessageBox.Show(string.Format("Your utterance may not contain both accessibility specifiers" +
               " (const, static, private, public, readonly) and parameter specifiers (ref, out, in). You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (vars && arrays) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain both var and array. You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (vars && structures) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain both var and struct. You said:{0}{1}",
               Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (equalsNews && !lists) {
            MessageBox.Show(string.Format(
               "Your utterance may not contain both \"equals new\" and anything other than \"List\"" + 
               " (with or without a list type). You said:{0}{1}", Environment.NewLine, pInput.Replace("equalsnew", "equals new")), 
               "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         if (objects)
            normalizedString += " object ";
         if (privateProtecteds)
            normalizedString += " private protected ";
         if (protectedInternals)
            normalizedString += " protected internal ";
         if (externals)
            normalizedString += " extern ";
         if (internals)
            normalizedString += " internal ";
         if (overrides)
            normalizedString += " override ";
         if (virtuals)
            normalizedString += " virtual ";
         if (constants)
            normalizedString += " const ";
         if (protecteds)
            normalizedString += " protected ";
         if (privates)
            normalizedString += " private ";
         if (publics)
            normalizedString += " public ";
         if (statics)
            normalizedString += " static ";
         if (references)
            normalizedString += " ref ";
         if (outs)
            normalizedString += " out ";
         if (ins)
            normalizedString += " in ";
         if (readOnlys)
            normalizedString += " readonly ";
         if (abstracts)
            normalizedString += " abstract ";
         if (asyncs)
            normalizedString += " async ";
         if (events)
            normalizedString += " event ";
         if (sealeds)
            normalizedString += " sealed ";
         if (unsafes)
            normalizedString += " unsafe ";
         if (volatiles)
            normalizedString += " volatiles ";

         if (vars)
            variableType = "var";
         else if (bytes)
            variableType = "byte";
         else if (sbytes)
            variableType = "sbyte";
         else if (bools)
            variableType = "bool";
         else if (characters)
            variableType = "char";
         else if (doubles)
            variableType = "double";
         else if (floats)
            variableType = "float";
         else if (strings)
            variableType = "string";
         else if (unsigneds && integers)
            variableType = "uint";
         else if (unsigneds && longs)
            variableType = "ulong";
         else if (unsigneds && shorts)
            variableType = "ushort";
         else if (!unsigneds && integers)
            variableType = "int";
         else if (!unsigneds && longs)
            variableType = "long";
         else if (!unsigneds && shorts)
            variableType = "short";
         else if (int16s)
            variableType = "int16";// int## are not legal for enume type
         else if (int32s)
            variableType = "int32";
         else if (int64s)
            variableType = "int64";
         else if (uint16s)
            variableType = "uint16";// uint## are not legal for enume type
         else if (uint32s)
            variableType = "uint32";
         else if (uint64s)
            variableType = "uint64";
         else if (voids)
            variableType = "void";
         if (unsigneds)
            uints = true;
         if (enumerators && (variables > 0)) {
            if (!bytes && !sbytes && !shorts && !ushorts && !integers && !uints && !longs && !ulongs) {
               MessageBox.Show(string.Format(
                  "Enums (enumerators) may may only be of types:{0}" +
                  "byte, sbyte, short, ushort, int, uint, long or ulong{0}" +
                  "You said:{0}{1}",
                  Environment.NewLine, pInput), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
         }
         if (lists) {
            normalizedString += " List<" + variableType + "> ";
            if (equalsNews)
               normalizedString += " = new List<" + variableType + ">";
         }
         else if (enumerators) {
            if (variables > 0) {
               lengthOfType = variableType.Length;
               normalizedString += "enum XXX : " + variableType + " {{}{ENTER}XXX = 0,{ENTER}XXX1 = 1{ENTER}{}}";
            }
            else
               normalizedString += "enum XXX {{}{ENTER}XXX = 0,{ENTER}XXX1 = 1{ENTER}{}}";
         }
         else if (equalsNews && !lists) {
            normalizedString += " = new XXX{(}{)};{LEFT 6}+{RIGHT 3}";
         }
         else//Variables
            normalizedString += variableType + " ";
         if ((construction > 0) && !cases) {
            if (functions)
               normalizedString += " XXX{(}{)} {{}{ENTER}{}}{UP}{END}{LEFT 7}+{RIGHT 3}";
            else if (structures)
               normalizedString += "struct XXX {{}{ENTER}{}}{UP}{END}{LEFT 5}+{RIGHT 3}";
            else if (classes) {
               if (partials)
                  normalizedString += " partial class XXX {{}{ENTER}{}}{UP}{END}{LEFT 5}+{RIGHT 3}";
               else
                  normalizedString += " class XXX {{}{ENTER}{}}{UP}{END}{LEFT 5}+{RIGHT 3}";
            }
         }
         normalizedString = CompressWhiteSpace(normalizedString);
         normalizedString = RemoveLeadingSpaces(normalizedString);
         normalizedString = RemoveTrailingSpaces(normalizedString);
         if (!string.IsNullOrEmpty(normalizedString) && !string.IsNullOrWhiteSpace(normalizedString) && !forEach) {
            ForceLeadingSpace();
            SendKeys.SendWait(normalizedString + " ");
         }
         List<string> usedWords = new List<string>() {
            "var", "void", "byte", "shortbyte","bool", "char", "double", "float", "integer", "unsigned", "long", "short", "list", "enumerate", "string",
            "override", "virtual", "constant", "private", "public", "protected", "internal", "protectedInternal", "privateProtected",
            "extern", "readonly", "reference", "out", "in", "array", "static", "equalsnew", "function", "structure", "class",
            "member", "global", "parameter", "pascal", "snake", "upper", "camel", "camel case", "class case", "pascal case", "snake case",
            "pascal snake case", "snake pascal case", "upper case","uppercase",  "upper snake case", "snake upper case", "case", "for each"};
         foreach (string usedWord in usedWords)
            trailingName = StringReplaceWord(trailingName, usedWord, String.Empty);
         trailingName = CompressWhiteSpace(trailingName);
         trailingName = RemoveLeadingSpaces(trailingName);
         trailingName = RemoveTrailingSpaces(trailingName);
         if (!string.IsNullOrEmpty(trailingName) && !string.IsNullOrWhiteSpace(trailingName) || forEach) {
            string prefix = string.Empty;
            //modifiers: camel (the default), pascal/capitals, snake, upper
            //types: mMember, gGlobal, pParameter
            if (members)
               prefix = "m";
            if (globals)
               prefix = "g";
            if (parameters)
               prefix = "p";
            if (uppers || upperCase || upperSnakeCase)
               trailingName = trailingName.ToUpper();
            else if (forEach) {
               if (variables == 0)
                  trailingName = CapitalizeAllWords(trailingName);
               if (strings)
                  trailingName = "string";
            }
            else if (!snakeCase)
               trailingName = CapitalizeAllWords(trailingName);
            if (snakes || snakeCase || pascalSnakeCase || upperSnakeCase)
               trailingName = trailingName.Replace(" ", "_");
            if (camels || camelCase)
               if (!members && !globals && !parameters)
                  trailingName = StringExtensions.FirstCharToLower(trailingName);
            trailingName = trailingName.Replace(" ", string.Empty);
            if (classes || enumerators || functions || structures)
               trailingName = StringExtensions.FirstCharToUpper(trailingName);
            if (forEach) {
               SendKeys.SendWait("foreach {(}  in whatList {)} {{}{ENTER}{}}{UP}{HOME}{Right 9}");
               if (variables > 0)
                  SendKeys.SendWait(variableType);
               else
                  SendKeys.SendWait(trailingName);
               if (strings)
                  trailingName = "phrase";
               else if (variables > 0)
                  trailingName = "number";
               else
                  trailingName = StringExtensions.FirstCharToLower(trailingName);
               SendKeys.SendWait("{RIGHT}");
               SendKeys.SendWait(trailingName);
               SendKeys.SendWait("{RIGHT 4}^+{RIGHT}+{LEFT}");
            }
            else if (enumerators && !cases) {
               if (variables > 0) {
                  SendKeys.SendWait("{UP 3}{END}");
                  lengthOfType = lengthOfType + 8;
                  for (int i = 0; i < lengthOfType; i++)
                     SendKeys.SendWait("{LEFT}");
                  SendKeys.SendWait("{DELETE 3}");
                  SendKeys.SendWait(prefix + trailingName);
               }
               else {
                  SendKeys.SendWait("{UP 3}{END}{LEFT 5}{DELETE 3}");
                  SendKeys.SendWait(prefix + trailingName);
               }
            }
            else if (lists && !cases) {
               if (variables > 0) {
                  SendKeys.SendWait("{END}");
                  lengthOfType = lengthOfType + 13;
                  for (int i = 0; i < lengthOfType; i++)
                     SendKeys.SendWait("{LEFT}");
                  SendKeys.SendWait(" " + prefix + trailingName);
               }
            }
            else if (!equalsNews)
               SendKeys.SendWait(prefix + trailingName + "{END}");//DEBUG efm5 2021 02 22 the {end} might not be appropriate everywhere
         }
      }
   }
}