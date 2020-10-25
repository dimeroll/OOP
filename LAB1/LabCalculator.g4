grammar LabCalculator; 

/*
* Parser Rules
*/


compileUnit : expression EOF;
expression :
LPAREN expression RPAREN #ParenthesizedExpr
|expression EXPONENT expression #ExponentialExpr
| expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
| expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
| expression EQUAL expression #EqualExpr                                                             
| expression LESS expression #LessExpr                                                               
| expression GREATER expression #GreaterExpr
| expression LESSEQUAL expression #LessEqualExpr
| expression GREATEREQUAL expression #GreaterEqualExpr
| expression NOTEQUAL expression #NotEqualExpr
| operatorToken=(MMAX | MMIN) LPAREN expression (COMMA expression)* RPAREN #MmaxMminExpr   
| NUMBER #NumberExpr
| IDENTIFIER #IdentifierExpr
;

/*
* Lexer Rules
*/
NUMBER : INT ('.' INT)?;
IDENTIFIER : [a-zA-Z]+[1-9][0-9]+;
INT : ('0'..'9')+;
EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : '/';
SUBTRACT : '-';
ADD : '+';
EQUAL : '=';
LESS : '<';
GREATER : '>';
LESSEQUAL : '<=';
GREATEREQUAL : '>=';
NOTEQUAL : '<>';
LPAREN : '(';
RPAREN : ')';
COMMA : ',';
MMAX : 'mmax';
MMIN : 'mmin';
WS : [\t\r\n] -> channel(HIDDEN);