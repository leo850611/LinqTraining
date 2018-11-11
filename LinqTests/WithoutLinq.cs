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


		internal static IEnumerable<T> YourSkip<T>(this IEnumerable<T> employees, int t)
		{
			int index = 0;
			var enumerator = employees.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (index >= t)
				{
					yield return enumerator.Current;
				}
				index += 1;
			}
		}


		public static IEnumerable<T> YourTakeWhile<T>(this IEnumerable<T> employees, int i, Func<T, bool> func)
		{
			int index = 0;
			var enumerator = employees.GetEnumerator();
			while (enumerator.MoveNext())
			{
				var result = enumerator.Current;
				if (index > i)
				{
					yield break;
				}

				if (func(enumerator.Current))
				{
					yield return result;
					index++;
				}
			}
		}

		public static IEnumerable<T> SkipWhile<T>(IEnumerable<T> employees, int i, Func<T, bool> func)
		{
			int index = 0;
			var enumerator = employees.GetEnumerator();
			while (enumerator.MoveNext())
			{
				var result = enumerator.Current;
				if (func(result) && index < i)
				{
					index++;
				}
				else
				{
					yield return result;
				}
			}
		}

		public static IEnumerable<int> YourGroup<T>(IEnumerable<T> employees, int i, Func<T, int> func)
		{
			int index = 0;
			var temp = 0;
			var enumerator = employees.GetEnumerator();
			while (enumerator.MoveNext())
			{
				var result = enumerator.Current;
				if (index < i)
				{
					temp += int.Parse(func(result).ToString());
					index++;
				}

				if (index == i)
				{
					yield return temp;
					index = 0;
					temp = 0;
				}
			}

			if (index != 0)
			{
				yield return temp;
			}
		}


	}
}