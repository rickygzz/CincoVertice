#include <string>

using namespace std;

class Strings
{
public:
    static string After(string text, string delimiter, bool trim = false)
    {
        int textLength = text.length();
        int delimiterLength = delimiter.length();

        for (int i = 0; i < (textLength - delimiterLength); i++)
        {
            if (text.substr(i, delimiterLength) == delimiter)
            {
                if (trim)
                {
                    return Trim(text.substr(i + delimiterLength));
                }

                return text.substr(i + delimiterLength);
            }
        }

        return '\0';
    }

    // Removes all leading and trailing white-spaces from the string.
    static string Trim(string& str)
    {
        while(str[0] == ' ')
            str.erase(str.begin());

        while(str[str.size() - 1] == ' ')
            str.pop_back();
        
        return str;
    }
};
