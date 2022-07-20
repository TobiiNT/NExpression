namespace NExpression.Core.Expressions.Operations
{
    public enum MathOperation
    {
        NoOperation,

        // Calculations
        Add, // '+'
        Subtract, // '-'
        Negative, // '-'
        Multiply, // '*'
        Divide, // '/'
        Modulus, // '%'
        Factorial, // '!'

        // Comparisons
        CompareGreaterThan, // >
        CompareLessThan, // <
        CompareGreaterThanOrEqual, // '>='
        CompareLessThanOrEqual, // '>'
        CompareValueEqual, // '=='
        CompareValueNotEqual, // '!='
        CompareValueAndTypeEqual, // '==='
        CompareValueAndTypeNotEqual, // '!=='

        // Bitwise logics
        BitwiseNOT, // '~'
        BitwiseAND, // '&'
        BitwiseXOR, // '^'
        BitwiseOR, // '|'
        BitwiseShiftLeft, //
        BitwiseShiftRight, //

        // Logicals
        LogicalAND, // '&&'
        LogicalOR, // '||'
        LogicalNOT, // '!'
        LogicalIFNULL, // '??'

        // Conditions
        ConditionTernary, // '?'

        // Assignments
        AssignEqual, // '='
        AssignAddAfterReturn, // '++'
        AssignAddBeforeReturn, // '++'
        AssignAdd, // '+='
        AssignSubtractAfterReturn, // '--'
        AssignSubtractBeforeReturn, // '--'
        AssignSubtract, // '-='
        AssignMultiply, // '*='
        AssignDivide, // '/='
        AssignModulus, // '%='
        AssignBitwiseAND, // '&='
        AssignBitwiseOR, // '|='
        AssignBitwiseXOR, // '^='
        AssignBitwiseShiftLeft, // '<<='
        AssignBitwiseShiftRight, // '>>='
        AssignIFNULL, // '??='

        GetItemByIndex,

        StringValue,
        CharValue,

        FunctionCall,
    }
}
