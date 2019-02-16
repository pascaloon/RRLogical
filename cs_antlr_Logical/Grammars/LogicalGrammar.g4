grammar LogicalGrammar;

/*
 * Parser Rules
 */

compileUnit
    : lineExpression
    | EOF
    ;

lineExpression
    : expression '\n'?
    ;

expression
    : LEFTP expression RIGHTP #Parenthesis
    | INV expression #Inverse
    | expression MULT expression #Multiplication
    | expression ADD expression #Addition    
    | ID #Identifier
    | CONSTANT #Constant
    ;

/*
 * Lexer Rules
 */

LEFTP: '(';
RIGHTP: ')';
MULT: '*' | '&' | '.';
ADD: '+' | '|';
INV: '!';
CONSTANT: '0' | '1';
INT: '0' .. '9';
ID: ('a' .. 'z' | 'A' .. 'Z'| '_' | INT)+;

//WS
//    :	' ' -> channel(HIDDEN)
//    ;
