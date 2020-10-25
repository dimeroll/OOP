using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LabCalculator
{
    class LabCalculatorVisitor : LabCalculatorBaseVisitor<double>
{
         //таблиця ідентифікаторів (тут для прикладу)
         //в лабораторній роботі заміните на свою!!!!
         Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();
public override double VisitCompileUnit(LabCalculatorParser.CompileUnitContext context)
    {
        return Visit(context.expression());
    }
    public override double VisitNumberExpr(LabCalculatorParser.NumberExprContext context)
    {
        var result = double.Parse(context.GetText());
        Debug.WriteLine(result);
        return result;
    }
    //IdentifierExpr
    public override double VisitIdentifierExpr(LabCalculatorParser.IdentifierExprContext context)
    {
        var result = context.GetText();
        double value;
        //видобути значення змінної з таблиці
        if (tableIdentifier.TryGetValue(result.ToString(), out value))
        {
            return value;
        }
        else
        {
            return 0;
        }
    }
    public override double VisitParenthesizedExpr(LabCalculatorParser.ParenthesizedExprContext context)
    {
        return Visit(context.expression());
    }
    public override double VisitAdditiveExpr(LabCalculatorParser.AdditiveExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);
        if (context.operatorToken.Type == LabCalculatorLexer.ADD)
        {
            Debug.WriteLine("{0} + {1}", left, right);
            return  left + right;
        }
        else //LabCalculatorLexer.SUBTRACT
        {
            Debug.WriteLine("{0} - {1}", left, right);
            return left - right;
        }
    }
    public override double VisitMultiplicativeExpr(LabCalculatorParser.MultiplicativeExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.MULTIPLY)
            {
                Debug.WriteLine("{0} * {1}", left, right);
                return left * right;
            }
            else //LabCalculatorLexer.DIVIDE
            {
                Debug.WriteLine("{0} / {1}", left, right);
                return left / right;
            }
        
    }
    public override double VisitEqualExpr(LabCalculatorParser.EqualExprContext context)
    {
         var left = WalkLeft(context);
         var right = WalkRight(context);
                Debug.WriteLine("{0} = {1}", left, right);
                return Convert.ToDouble(left == right);
    }
    public override double VisitLessExpr(LabCalculatorParser.LessExprContext context)
    {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("{0} < {1}", left, right);
            return Convert.ToDouble(left < right);
    }
    public override double VisitGreaterExpr(LabCalculatorParser.GreaterExprContext context)
    {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("{0} > {1}", left, right);
            return Convert.ToDouble(left > right);
    }
    public override double VisitLessEqualExpr(LabCalculatorParser.LessEqualExprContext context)
    {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("{0} <= {1}", left, right);
            return Convert.ToDouble(left <= right);
    }
    public override double VisitGreaterEqualExpr(LabCalculatorParser.GreaterEqualExprContext context)
    {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("{0} >= {1}", left, right);
            return Convert.ToDouble(left >= right);
    }
    public override double VisitNotEqualExpr(LabCalculatorParser.NotEqualExprContext context)
    {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("{0} <> {1}", left, right);
            return Convert.ToDouble(left != right);
    }

    public override double VisitMmaxMminExpr(LabCalculatorParser.MmaxMminExprContext context)
    {
            List<double> list = new List<double>();
            int idx = 0;
            while (WalkN(context, idx) != 1.0101) 
            { 
                list.Add(WalkN(context, idx));
                idx++; 
            }
            var sortedList = from l in list orderby l select l;
            if (context.operatorToken.Type == LabCalculatorLexer.MMAX)
            {
                Debug.WriteLine("mmax(");
                for(idx = 0; idx < list.Count(); ++idx) 
                { 
                    Debug.WriteLine("{0} ", list.ElementAt(idx));
                    if (idx != list.Count() - 1) Debug.WriteLine(" , ");
                }
                Debug.WriteLine(")");
                return sortedList.ElementAt(sortedList.Count() - 1);
            }
            else //LabCalculatorLexer.MMIN
            {
                Debug.WriteLine("mmin(");
                for (idx = 0; idx < list.Count(); ++idx)
                {
                    Debug.WriteLine("{0} ", list.ElementAt(idx));
                    if (idx != list.Count() - 1) Debug.WriteLine(" , ");
                }
                Debug.WriteLine(")");
                return sortedList.ElementAt(0);
            }



    }


        private double WalkLeft(LabCalculatorParser.ExpressionContext context)
        {
            return  Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(0));
        }
        private double WalkRight(LabCalculatorParser.ExpressionContext context)
        {
            return  Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(1));
        }
        private double WalkN(LabCalculatorParser.ExpressionContext context, int idx)
        {
            try
            {
                return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(idx));
            }
            catch(NullReferenceException) { return 1.0101; }

        }

    }
}

