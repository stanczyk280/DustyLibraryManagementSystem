using DustyLibraryManagementSystem.Domain;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq.Indexing;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustyLibraryManagementSystem.Persistence
{
    public static class Seed
    {
        public static async Task SeedData(IAsyncDocumentSession session)
        {
            var cultureInfo = new CultureInfo("pl-PL");
            var query = from Book in session.Query<Book>() select Book;
            var result = await query.ToListAsync();
            if (result.Count() != 0) return;

            var books = new List<Book>
            {
                new Book()
                {
                    Title= "Title",
                    Author = "Author",
                    Publisher = "Publisher",
                    Published = DateTime.Parse("1 stycznia 1998", cultureInfo),
                    Category= "Category",
                    Description = "Description",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 1,
                        Borrowed = 0
                    }
                },
                new Book()
                {
                    Title= "Ołowiany Świt",
                    Author = "Michał Gołkowski",
                    Publisher = "Fabryka Słów",
                    Published = DateTime.Parse("26 kwietnia 2013", cultureInfo),
                    Category= "Fantastyka",
                    Description = "Zona - tajemnica, która wciąga, kusi i intryguje.\r\n\r\nJej historią jest świat współczesny. Jej dzieci to my.\r\n\r\nUniwersum S.T.A.L.K.E.R.a oczami Polaka – stara mleczarnia, martwy cieć, zapomniany kalendarz i wieża w środku lasu.\r\n\r\nWchodzisz w to? Zresztą, już jesteś. Wszyscy jesteśmy – stalkerami. Dziećmi Sarkofagu.\r\n\r\nTutaj wrogiem jest zło, które może czaić się tuż obok, za naszymi plecami. Może przyjmować różne postaci, imiona i kształty; jednak najstraszniejszym, co możemy spotkać w Zonie - jest człowiek.\r\n\r\nWstaje nowy dzień. Czy przeżyjesz go - całym sobą?",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 100,
                        Borrowed = 0
                    }
                },
                new Book()
                {
                    Title= "Stalowe Szczury. Błoto",
                    Author = "Michał Gołkowski",
                    Publisher = "Fabryka Słów",
                    Published = DateTime.Parse("1 stycznia 2015", cultureInfo),
                    Category= "Fantastyka",
                    Description = "Wiosna 1922. Samobójcze natarcie na pozycje przeciwnika po raz kolejny prowadzi kapral Reinhardt i jego kompania karna – kundle wojny, dezerterzy, podpalacze i najgorsze szumowiny. Straceńcy gotowi na wszystko.",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 150,
                        Borrowed = 0
                    }
                },
                new Book()
                {
                    Title= "Komornik",
                    Author = "Michał Gołkowski",
                    Publisher = "Fabryka Słów",
                    Published = DateTime.Parse("1 stycznia 2016", cultureInfo),
                    Category= "Fantastyka",
                    Description = "Nadchodzi Koniec.\r\nAle taki w cholerę prawdziwy, biblijny. Ziemia zatrzymuje się, gwiazdy spadają, woda zamienia się w krew. Umarli wstają z grobów, otwiera się otchłań. Państwa upadają, brat powstaje przeciw bratu, a dzieci podnoszą rękę na rodziców. Widać, że lada chwila świat spłonie.\r\nTylko że coś w systemie nie zaskoczyło. Generalnie, zasadniczo i pobieżnie: zamiast bomby termojądrowej wychodzi fajerwerk.",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 80,
                        Borrowed = 0
                    }
                },
                new Book()
                {
                    Title= "Inside RavenDB 4.0",
                    Author = "Oren Eini",
                    Publisher = "HybernatingRhinos",
                    Published = DateTime.Parse("1 stycznia 2017", cultureInfo),
                    Category= "Poradniki",
                    Description = "What you're reading now is effectively a book-length blog post. The main idea here is that I want to give you a way to grok RavenDB.2 This means not only gaining knowledge of what RavenDB does, but also all the reasoning behind the bytes. In effect, I want you to understand all the whys of RavenDB.",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 200,
                        Borrowed = 0
                    }
                },
            };

            foreach (var book in books)
            {
                await session.StoreAsync(book);
            };
            await session.SaveChangesAsync();
        }
    }
}