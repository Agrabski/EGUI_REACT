using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EGUI_REACT.Controllers
{
	public class BooksController : ApiController
	{
		List<Book> _books = new List<Book>() { new Book()
		{
			Author="",
			Title=""
		}
			,new Book()
		{
			Author="",
			Title=""
		}};
		// GET api/values
		public IEnumerable<Book> Get()
		{
			return _books;
		}

		// GET api/values/5
		public Book Get(int id)
		{
			return _books[id];
		}

		// POST api/values
		public void Post([FromBody]Book value)
		{
			_books.Add(value);
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]Book value)
		{
			_books[id] = value;
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
			_books.RemoveAt(id);
		}
	}
}
