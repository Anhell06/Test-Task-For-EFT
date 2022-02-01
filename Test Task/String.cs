namespace Test_Task
{
    public static class String
    {
        public static string TrimString(this string sentence, string firstWord, string LastWord) =>
            sentence.Substring(sentence.IndexOf(firstWord) + firstWord.Length, sentence.IndexOf(LastWord) - LastWord.Length);
    }
}
