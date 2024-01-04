using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_NETMaui.Models
{
    public class StarRatingView : StackLayout
    {
        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create(nameof(Rating), typeof(double), typeof(StarRatingView), 0.0, propertyChanged: OnRatingPropertyChanged);

        public double Rating
        {
            get { return (double)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        private static void OnRatingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var starRatingView = (StarRatingView)bindable;
            starRatingView.UpdateStars();
        }

        private void UpdateStars()
        {
            var starStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                Spacing = 0, // Adjust the spacing between stars if needed
            };

            for (int i = 0; i < 5; i++)
            {
                var starImage = new Image
                {
                    Source = GetStarImage(i + 1),
                    HeightRequest = 20,
                    WidthRequest = 20,
                };

                starStack.Children.Add(starImage);
            }

            Children.Clear();
            Children.Add(starStack);
        }

        private string GetStarImage(int starNumber)
        {
            double starValue = starNumber - 0.5; // Adjust the star value for half-filled stars

            const double epsilon = 0.01;

            if (Rating >= starValue - epsilon)
            {
                if (Rating >= starValue + epsilon)
                {
                    return "star_filled.png"; // Return filled star
                }
                else
                {
                    return "star_half_filled.png"; // Return half-filled star
                }
            }
            else
            {
                return "star_empty.png"; // Return empty star
            }
        }
    }
}

