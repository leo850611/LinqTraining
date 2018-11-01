using System;
using System.Collections.Generic;
using System.Linq;
using LinqTests;

namespace LinqSample.WithoutLinq
{
	internal static class WithoutLinq
	{
		public static IEnumerable<Product> Find(IEnumerable<Product> products, Func<Product, bool> func)
		{
			foreach (var p in products)
			{
				if (func(p))
				{
					yield return p;
				}
			}
		}



		internal static IEnumerable<T> Find<T>(this IEnumerable<T> employees, Func<T, int, bool> p)
		{
			int index = 0;
			foreach (var employee in employees)
			{

				if (p(employee, index))
				{
					yield return employee;
				}

				index += 1;
			}
		}


		internal static IEnumerable<T> YourWhere<T>(this IEnumerable<T> employees, Func<T, bool> p)
		{
			int index = 0;
			foreach (var employee in employees)
			{

				if (p(employee))
				{
					yield return employee;
				}

				index += 1;
			}
		}

		internal static IEnumerable<T2> YourSelect<T, T2>(this IEnumerable<T> employees, Func<T, T2> p)
		{
			foreach (var employee in employees)
			{
				yield return p(employee);
			}
		}


		internal static IEnumerable<T> YourTake<T>(this IEnumerable<T> employees, int t)
		{
			int index = 0;
			foreach (var employee in employees)
			{
				if (index < t)
				{
					yield return employee;
				}
				index += 1;
			}
		}

	}
}