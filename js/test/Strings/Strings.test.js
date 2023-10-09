const Strings = require('./../../app/Strings/Strings');

describe("Unit Tests for Strings Class", () => {
    test('1) After tests', () => {
        const test1 = "A = B ";

        // Must return string after delimiter = without trimming.
        expect(Strings.After(test1, "=")).toBe(" B ");

        // Must return trimmed string after delimiter =
        expect(Strings.After(test1, "=", true)).toBe("B");

        // Must return string after first delimiter is found.
        expect(Strings.After(test1, " ")).toBe("= B ");

        // Must return trimmed string after first delimiter is found.
        expect(Strings.After(test1, " ", true)).toBe("= B");

        // Must return "" if delimiter is not found
        expect(Strings.After(test1, "?")).toBe("");
        expect(Strings.After(test1, "?", true)).toBe("");

        // Compounded delimiter: Must return string after first delimiter is found.
        expect(Strings.After(test1, "= B")).toBe(" ");

        // Compounded delimiter: Must return trimmed string after first delimiter is found.
        expect(Strings.After(test1, "= B", true)).toBe("");

        // Working with multi-line text.
        const test2 = "A\n\n = B ";

        expect(Strings.After(test2, "=")).toBe(" B ");
        expect(Strings.After(test2, "=", true)).toBe("B");
        expect(Strings.After(test2, "\n\n")).toBe(" = B ");
        expect(Strings.After(test2, "\n\n", true)).toBe("= B");
    });
})
