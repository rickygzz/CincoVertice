class Strings
{
    static After(text, delimiter, trim = false)
    {
        if (text === undefined || text === null)
        {
            return "";
        }

        if (delimiter === undefined || delimiter === null)
        {
            return "";
        }

        const textLength = String(text).length;
        const delimiterLength = String(delimiter).length;

        console.log('Text' + text + '   TextLength ' + textLength);

        for (var i = 0; i < (textLength - delimiterLength); i++)
        {
            if (text.substr(i, delimiterLength) == delimiter)
            {
                if (trim)
                {
                    return text.substr(i + delimiterLength).trim();
                }

                return text.substr(i + delimiterLength);
            }
        }

        return "";
    }
}

module.exports = Strings