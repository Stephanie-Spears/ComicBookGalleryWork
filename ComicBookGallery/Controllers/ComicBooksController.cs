using ComicBookGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookGallery.Controllers
{
    //controller classes need to be public, or MVC won't be able to access them. As do action methods inside of them (Detail action method)
    //mvc url maps to path with -> Pattern = controller/action
    //Controller = ComicBooks, Action = Detail
    //-> so a url that maps to /ComicBooks/Detail
    //Action Method -> Index
    //ContentResult is an action result type provided by MVC. 
    //RedirectResult is another action result type used to redirect a user to another url
    //alt + F12 peaks the class def

    public class ComicBooksController : Controller
    {
        public ActionResult Detail()
        {
            var comicBook = new ComicBook() {
                SeriesTitle = "The Amazing Spider-Man",
                IssueNumber = 700,
                DescriptionHtml = "<p>Final issue! Witness the final hours of Doctor Octopus' life and his one, last, great act of revenge! Even if Spider-Man survives... <strong>will Peter Parker?</strong></p>",
                Artists = new Artist[]
                {
                    new Artist(){ Name = "Dan Slott", Role = "Script"},
                    new Artist(){ Name = "Huberto Ramos", Role = "Pencils"},
                    new Artist(){ Name = "Victor AOlazaba", Role = "Inks"},
                    new Artist(){ Name = "Edgar Delgado", Role = "Colors"},
                    new Artist(){ Name = "Chis Eliopoulos", Role = "Letters"},
                }
            };

            return View(comicBook);
        }
    }
}

//Every controller in ASP.NET MVC must inherit from the Controller base class. In ASP.NET MVC, a "page" is represented by the combination of a controller and a view.
//All of the ASP.NET MVC action result types, including ContentResult, RedirectResult, and ViewResult, share the common ActionResult base class.

//Given a controller named Home and an action method named About, calling the View method without any parameters will cause MVC to look for a view named About.cshtml in the “Views/Home” folder.

//The Controller base class View method can be used to return a ViewResult object from an action method.

//the @{} symbol is part of Razor which allows us to mix C# and HTML. using the @ tells the editor that we want to switch to using c# in a .cshtml file
//the layout prop in @{ Layout = null; } is used to set the path to our layout page. It allows us to specify what markup to use--> setting it to null says we arent using any layout pages.
//MVC will escape our HTML by default. We can prevent it from doing that by adding the @Html.Raw() method to the value. If Razor ever gets confused as to when you've switched back out of writing C# code, you can surround the code in parenthesis

//ViewBag is an object provided by MVC that allows us to pass data from a controller to a view. It's of type Dynamic, which allows us to define properties on the ViewBag object without having to modify a class. One of the disadvantages to this dynamic type is that intellisense can't suggest property names in other files. Also, ViewBag properties aren't case-sensitive, but it's good practice to use same case properties across files. Final note-> Errors like misspelling the property names won't get highlighted, and won't prompt an error message--instead it just won't render the misspelled propety (so be careful).

//ActionLink method is used to generate a link

//RenderBody() method is used to tell MVC where we'd like to have the content from the view included. A layout page can only contain a single call to the RenderBody() method. 

//In ASP.NET MVC, layout pages specify the overall look/feel of your webstie pages without having to include the markup in each view


//Strongly typed means the object type is known and available. We used this in views to refer to the Model object (ComicBook)-->@model Treehouse.Models.ComicBook