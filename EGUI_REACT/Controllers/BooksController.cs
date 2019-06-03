using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;

namespace EGUI_REACT.Controllers
{
	public class BooksController : ApiController
	{
		static object syncRoot = new object();
		public List<Book> Books
		{
			get
			{
				lock (syncRoot)
				{
					var books = new List<Book>();
					using (var stream = new FileStream("d:\\books.why_is_this_happening_to_me_im_loosing_my_sanity", FileMode.Open))
					{
						var deserializer = new XmlSerializer(books.GetType());
						foreach (var book in deserializer.Deserialize(stream) as IEnumerable<Book>)
							books.Add(book);
					}
					return books;

				}
			}
			set
			{
				lock (syncRoot)
				{
					using (var stream = new FileStream("d:\\books.why_is_this_happening_to_me_im_loosing_my_sanity", FileMode.Create))
					{
						var deserializer = new XmlSerializer(value.GetType());
						deserializer.Serialize(stream, value);
					}
				}
			}
		}

		public BooksController()
		{
			if (!File.Exists("d:\\books.why_is_this_happening_to_me_im_loosing_my_sanity"))
				Books = new List<Book>() { new Book() { Author = "", Title = "" }, new Book() { Author = "", Title = "" } };


		}
		// GET api/values
		public IEnumerable<Book> Get()
		{
			return Books;
		}

		// GET api/values/5
		public Book Get(int id)
		{
			return Books[id];
		}

		// POST api/values
		public void Post([FromBody]Book value)
		{
			var books = Books;
			books.Add(value);
			Books = books;
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]Book value)
		{
			var books = Books;
			books[id] = value;
			Books = books;
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
			var books = Books;
			books.RemoveAt(id);
			Books = books;
		}
	}
}
