using ComicBookGallery.Data;
using ComicBookGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/* global.asax file (application file) at file root. Contains global/application level code. Ours has just one method --> application start method. We can use this method to run any code to initialize our website. */


namespace ComicBookGallery.Controllers
{
    /*
     ctrl + tab ... switch windows
     ctrl + , ... navigate to
     Shift + Enter ... end line with semicolon
     ctrl + Shift + B ... build project
     ctrl + . ... lightbulb suggestions
     alt + F12 ... peak class definition
     ctrl + r + r ... rename class

        Debugging
        F5 ... continue
        F10 ... step over
        F11 ... step into
        Shift + F11 ... step out

         */
    /*
     * * MVC url maps to path with: Pattern = controller/action
     * * Controller = ComicBooks, Action = Detail -> so a url that maps to /ComicBooks/Detail
     * * ContentResult is an action result type provided by MVC.
     * * RedirectResult is another action result type used to redirect a user to another url
     * * controller classes need to be public, or MVC won't be able to access them. As do action methods inside of them (Detail action method)
    */

    public class ComicBooksController : Controller
    {
        private ComicBookRepository _comicBookRepository = null;

        public ComicBooksController() //constructor-> used to initialize instance members. No return type, name matches class name.
        {
            _comicBookRepository = new ComicBookRepository();
        }

        public ActionResult Index() //left click View, add View...Index, Empty without Model. This adds an Index View template
        {
            var comicBooks = _comicBookRepository.GetComicBooks();
            return View(comicBooks);
        }

        public ActionResult Detail(int? id) //? allows for nullable values, so if there is no id argument given, the controller can still route
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var comicBook = _comicBookRepository.GetComicBook((int)id); //when using a nullable type you need to use the value property to get the underlying property. Or you can cast it.

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

//SOLID -> Five Design Principles:
//Single responsibility principle
//      a class should have only a single responsibility(i.e.changes to only one part of the software's specification should be able to affect the specification of the class).
//Open/closed principle
//      software entities … should be open for extension, but closed for modification.
//Liskov substitution principle
//      objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program." See also design by contract.
//Interface segregation principle
//      many client-specific interfaces are better than one general-purpose interface.
//Dependency inversion principle
//      one should "depend upon abstractions, [not] concretions.

//naming convention for private fields is to use an underscore with a lower-start camel case

/*

 *  DEBUGGING -> When an error occurs during debugging and stops program execution you can hit F5 to continue the debugging process
 *  Step Into and Step Over both tell the debugger to execute the next line of code, but they handle method calls differently.
 *  Step Into will execute the method call and suspend execution on the first line of code in the method.
 *  Step Over will execute the entire method and suspend execution on the next line of code after the method call.
 *  When you Step Into a method call, Step Out will finish executing that method and return you to the calling method

public void SomeMethod()
{
    int value = 4;
    int result = AnotherMethod(value);
    ***STEP OVER will Stop here***
        Console.WriteLine("My result: {0}", result);
}
public int AnotherMethod(int anotherValue)
{
    ***STEP INTO will stop here****
        int value = 2;
    int result = value * anotherValue;
    return value;
}

Step OVER -> F10
Step INTO -> F11
Step OUT -> Shift + F11

*/
