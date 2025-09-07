using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ShanYue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Util
{
    public class ExpressionFactory<T> where T : class, new()
    {
        private Expression<Func<T, bool>> expression = null;

        public Expression<Func<T, bool>> Init(Expression<Func<T, bool>> exp)
        {
            expression = exp;
            return expression;
        }

        public static ExpressionFactory<T> Create(Expression<Func<T, bool>> exp)
        {
            ExpressionFactory<T> expressionFactory = new ExpressionFactory<T>();
            expressionFactory.Init(exp);
            return expressionFactory;
        }

        public Expression<Func<T, bool>> And(Expression<Func<T, bool>> exp)
        {
            if (exp == null) throw new ArgumentNullException("表达式不可为空!");
            if (expression == null) return Init(exp);

            //统一参数
            ParameterExpression newParameter = expression.Parameters.First();
            var replaceBody = ReplaceParameter(exp, newParameter);

            expression = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expression.Body, replaceBody), newParameter);
            return expression;
        }

        public Expression<Func<T, bool>> AndIF(bool condition, Expression<Func<T, bool>> exp)
        {
            if(!condition)
            {
                return expression;
            }
            if(exp == null) throw new ArgumentNullException("表达式不可为空!");
            if(expression == null) return Init(exp);

            //统一参数
            ParameterExpression newParameter = expression.Parameters.First();
            var replaceBody = ReplaceParameter(exp, newParameter);

            expression = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expression.Body, replaceBody), newParameter);
            return expression;
        }

        public Expression<Func<T, bool>> Or(Expression<Func<T, bool>> exp)
        {
            if (exp == null) throw new ArgumentNullException("表达式不可为空!");
            if (expression == null) return Init(exp);

            //统一参数
            ParameterExpression newParameter = expression.Parameters.First();
            var replaceBody = ReplaceParameter(exp, newParameter);

            expression = Expression.Lambda<Func<T, bool>>(Expression.OrElse(exp.Body, replaceBody), newParameter);
            return expression;
        }

        public Expression<Func<T, bool>> OrIF(bool condition, Expression<Func<T, bool>> exp)
        {
            if (!condition)
            {
                return expression;
            }
            if (exp == null) throw new ArgumentNullException("表达式不可为空!");
            if (expression == null) return Init(exp);

            //统一参数
            ParameterExpression newParameter = expression.Parameters.First();
            var replaceBody = ReplaceParameter(exp, newParameter);

            expression = Expression.Lambda<Func<T, bool>>(Expression.OrElse(exp.Body, replaceBody), newParameter);
            return expression;
        }

        public Expression<Func<T, bool>> ToExpression()
        {
            return expression;
        }

        private Expression ReplaceParameter(Expression<Func<T, bool>> exp, ParameterExpression newParameter)
        {
            return new ParameterVisitor(exp.Parameters.First(), newParameter).Visit(exp.Body);
        }

    }


    public class ParameterVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _oldParameter;
        private readonly ParameterExpression _newParameter;

        public ParameterVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
        {
            _oldParameter = oldParameter;
            _newParameter = newParameter;
        }

        /// <summary>
        /// 参数替换关键方法 由Visit方法调用
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _oldParameter == node ? _newParameter : node;
        }
    }
}
