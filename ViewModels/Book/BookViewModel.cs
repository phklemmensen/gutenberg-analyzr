using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.ViewModels.Book 
{	
	public sealed class BookViewModel 
	{
		public BookViewModel(string title, string content) {
			Title = title;
			Content = content;
		}
		public string Title {  get; private set;}
		
		public string Content { get; private set;}
		
		public int WordCountAll { 
			get {
				return Content.Split(' ').Length;
			}
		}
		
		public Dictionary<string, int> WordCountByWord {
			get {
				var grouped = Content.Split(' ')
							.GroupBy(word => word)
							.OrderByDescending(groupp => groupp.Count())
							.OrderByDescending(groupp => groupp.Key)
							.Select(groupp => new { Key = groupp.Key, Count = groupp.Count() });
				return grouped.ToDictionary(g => g.Key, g => g.Count);						
			}
		}
	}
}

