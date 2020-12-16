using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phephi.Models;

namespace Phephi.Controllers {
    public class HomeController : Controller {

        public ActionResult Index( ) {
            return View();
        }
        public ActionResult TakeSurvey( ) {
            return View( new PersonModel() );
        }

        [HttpPost]
        public ActionResult TakeSurvey( PersonModel person ) {

            // If age and date of birth don't match add error to your model,display via ModelState.AddModelError
            if(DateTime.Now.Year - person.DateOfBirth.Year != person.Age) {
                ModelState.AddModelError( "", "Date of birth and Age don't match." );
            }
            // handling radio butttons not selected.
            if(string.IsNullOrEmpty( person.ILikeToEatOut ) ||
                string.IsNullOrEmpty( person.ILikeToWatchMovies ) ||
                string.IsNullOrEmpty( person.ILikeToWatchTV ) ||
                string.IsNullOrEmpty( person.ILikeToListenToTheRadio )) {
                ModelState.AddModelError( "", "Select at least one button from each row" );
            }
            // check if model doesn't have any errors via ModelState.Isvalid before saving any data.
            if(ModelState.IsValid) {
                using(DatabaseConnectionClass dbConnection = new DatabaseConnectionClass()) {
                    dbConnection.People.Add( person );
                    dbConnection.SaveChanges();
                    return View( "Index" );
                }
            }
            return View( new PersonModel() );
        }

        public ActionResult ViewSurvey( ) {
            using(DatabaseConnectionClass dbConnection = new DatabaseConnectionClass()) {
                var persons = dbConnection.People.ToList();
                var totalNumberOfSurvey = 0;
                foreach(var person in persons) {
                    totalNumberOfSurvey += 1;
                }

                var averageAge = 0;
                var totalSumAge = 0;
                foreach(var person in persons) {
                    totalSumAge += person.Age;
                }

                averageAge = totalSumAge / totalNumberOfSurvey;

                List<int> allAges = new List<int>();
                foreach(var person in persons) {
                    allAges.Add( person.Age );
                }
                int maxAge = allAges.Max();
                int minAge = allAges.Min();

                int truePizzaTotal = 0;
                double pizzaPercentage;
                foreach(var person in persons) {
                    if(person.Pizza == true) {
                        truePizzaTotal += 1;
                    }
                }

                pizzaPercentage = Math.Round( ((double)truePizzaTotal / totalNumberOfSurvey) * 100, 1 );

                int truePastaTotal = 0;
                double pastaPercentage;
                foreach(var person in persons) {
                    if(person.Pasta == true) {
                        truePastaTotal += 1;
                    }
                }

                pastaPercentage = Math.Round( ((double)truePastaTotal / totalNumberOfSurvey) * 100, 1 );

                int truePapTotal = 0;
                double papPercentage;
                foreach(var person in persons) {
                    if(person.PapAndWors == true) {
                        truePapTotal += 1;
                    }
                }

                papPercentage = Math.Round( ((double)truePapTotal / totalNumberOfSurvey) * 100, 1 );

                int eatOutTotal = 0;
                double eatOutPercentage;
                foreach(var person in persons) {
                    if(!string.IsNullOrEmpty( person.ILikeToEatOut )) {
                        eatOutTotal += 1;
                    }
                }

                eatOutPercentage = Math.Round( ((double)eatOutTotal / totalNumberOfSurvey) * 100, 1 );

                int watchMoviesTotal = 0;
                double watchMoviesPercentage;
                foreach(var person in persons) {
                    if(!string.IsNullOrEmpty( person.ILikeToWatchMovies )) {
                        watchMoviesTotal += 1;
                    }
                }

                watchMoviesPercentage = Math.Round( ((double)watchMoviesTotal / totalNumberOfSurvey) * 100, 1 );

                int watchTVTotal = 0;
                double watchTVPercentage;
                foreach(var person in persons) {
                    if(!string.IsNullOrEmpty( person.ILikeToWatchTV )) {
                        watchTVTotal += 1;
                    }
                }

                watchTVPercentage = Math.Round( ((double)watchTVTotal / totalNumberOfSurvey) * 100, 1 );

                int listenRadioTotal = 0;
                double listenRadioPercentage;
                foreach(var person in persons) {
                    if(!string.IsNullOrEmpty( person.ILikeToListenToTheRadio )) {
                        listenRadioTotal += 1;
                    }
                }

                listenRadioPercentage = Math.Round( ((double)listenRadioTotal / totalNumberOfSurvey) * 100, 1 );


                var viewObject = new
                {
                    TotalNumberOfSurvey = totalNumberOfSurvey,
                    AverageAge = averageAge,
                    MaxAge = maxAge,
                    MinAge = minAge,
                    PizzaPercentage = pizzaPercentage,
                    PastaPercentage = pastaPercentage,
                    PapPercentage = papPercentage,
                    WatchMoviesPercentage = watchMoviesPercentage,
                    WatchTVPercentage = watchTVPercentage,
                    ListenRadioPercentage = listenRadioPercentage
                };
                 return View(viewObject);
            }
        }
    }
}