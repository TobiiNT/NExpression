namespace NExpression.Core.Tokens
{
    public enum Token
    {
        EOF,
        OpenParenthesis, // (
        CloseParenthesis, // )
        OpenBlacket, // [
        CloseBlacket, // ]
        OpenBrace, // {
        CloseBrace, // }
        Comma, // ,
        Dot, // .
        SingleColon, // :
        SemiColon, // ;
        SingleExclamation, // !
        SingleQuestion, // ?
        DoubleQuestion, // ??
        DoubleQuestionAndEqual, // ??=
        SingleQuote, // '
        DoubleQuote, // "
        SingleDash, // -
        SingleDashAndEqual, // -=
        DoubleDash, // --
        SingleCross, // +
        SingleCrossAndEqual, // +=
        DoubleCross, // ++
        SingleAsterisk, // *
        SingleAsteriskAndEqual, // *
        SingleSlash, // /
        SingleSlashAndEqual, // /
        SingleBackSlash, // \
        SinglePercent, // %
        SinglePercentAndEqual, // %
        SingleTilde, // ~
        SingleCaret, // ^
        SingleCaretAndEqual, // ^=
        SinglePipe, // |
        DoublePipe, // ||
        SinglePipeAndEqual, // |=
        SingleAmpersand, // &
        DoubleAmpersand, // &&
        SingleAmpersandAndEqual, // &=
        SingleGreaterThan, // >
        DoubleGreaterThan, // >>
        SingleGreaterThanAndEqual, // >=
        DoubleGreaterThanAndEqual, // >>=
        SingleLessThan, // <
        DoubleLessThan, // <<
        SingleLessThanAndEqual, // <=
        DoubleLessThanAndEqual, // <<=
        SingleEqual, // =
        DoupleEqual, // ==
        TripleEqual, // ===
        SingleExclamationAndSingleEqual, // !=
        SingleExclamationAndDoubleEqual, // !==
        
        Identifier,
        Character,
        Number,

        // Keyword
        KeywordVar,

        KeywordNull,
        KeywordTrue,
        KeywordFalse,

        KeywordBoolean,
        KeywordByte,
        KeywordSByte,
        KeywordShort,
        KeywordUShort,
        KeywordInt,
        KeywordUInt,
        KeywordLong,
        KeywordULong,
        KeywordDouble,
        KeywordFloat,
        KeywordDecimal,

        KeywordIf,
        KeywordElse,
    }
}