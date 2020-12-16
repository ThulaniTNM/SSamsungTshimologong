using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Phephi.Models {
    public class PersonModel {
        [Column( name: "Person Identification" )]
        public int PersonModelID { get; set; }
        [Required( ErrorMessage = "Surname required" )]
        public string Surname { get; set; }

        [Required( ErrorMessage = "Name required" )]
        public string FirstName { get; set; }

        [Required( ErrorMessage = "Phone number" )]
        [RegularExpression( @"^0[678]\d{8}$", ErrorMessage = "10 digit number required , Eg 0766569436" )]
        // Remove comment, Regular expression to enforce format of contact number. Number should start with zero,followed by either a 6,7,8 then followed by 8 numbers-> \d{8}. 10 digit numbers required in total.
        public string contact { get; set; }

        [Required( ErrorMessage = "Date Required" )]
        [DataType( DataType.Date )] // For displaying calender for user input
        public DateTime DateOfBirth { get; set; }

        [Required( ErrorMessage = "Age Required" )]
        [Range( 5, 120, ErrorMessage = "Age between 5 and 120" )] // Remove comment,Range specifies number should range from 5 to 120 including 120.
        public int Age { get; set; }

        public bool Pizza { get; set; }
        public bool Pasta { get; set; }
        [Column( name: "Pap and Wors" )]
        public bool PapAndWors { get; set; }
        [Column( name: "Chicken Stir Fry" )]
        public bool ChickenStirFry { get; set; }
        [Column( name: "Beef Stir Fry" )]
        public bool BeefStirFry { get; set; }
        public bool Other { get; set; }

        [Required( ErrorMessage = "Select at least one like" )]
        [Column( name: "I like to eat out" )]
        public string ILikeToEatOut { get; set; }

        [Required( ErrorMessage = "Select at least one like" )]
        [Column( name: "I like to watch movies" )]
        public string ILikeToWatchMovies { get; set; }

        [Required( ErrorMessage = "Select at least one like" )]
        [Column( name: "I like to watch TV" )]
        public string ILikeToWatchTV { get; set; }

        [Required( ErrorMessage = "Select at least one like" )]
        [Column( name: "I like to listen to the radio" )]
        public string ILikeToListenToTheRadio { get; set; }

        [NotMapped] // Remove comment,to prevent property from being included in database creation
        public string[] likesDisplay { get; set; } // for displaying first column

        [NotMapped]
        public string[] keys { get; set; }

        public PersonModel( ) {
            keys = new string[]
            {
               "ILikeToEatOut","ILikeToWatchMovies" ,"ILikeToWatchTV","ILikeToListenToTheRadio"
            };

            // data to display for first column
            likesDisplay = new string[]{
                "I like to eat out",
                "I like to watch movies",
                "I like to watch TV",
                "I like to listen to the radio"
            };
        }


    }
}