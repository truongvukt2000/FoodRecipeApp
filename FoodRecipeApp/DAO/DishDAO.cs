﻿using FoodRecipeApp.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoodRecipeApp.DAO
{
    class DishDAO
    {
        private static DishDAO instance;

        public static DishDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DishDAO();
                return instance;
            }
            private set => instance = value;
        }

        private DishDAO() { }

        public DataTable getAllDishes()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_getAllDishes");
        }

        public DataTable getFavouriteDishes()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_getFavouriteDishes");
        }

        internal void addNewDish(Dish newDish)
        {
            string IsLove = (newDish.IsLove == true ? 1 : 0 ).ToString();
            string Name = newDish.Name;
            string Video = newDish.Video;
            string Description = newDish.Desciption;
            string FilePath = newDish.ImagePath;
            string Loai = newDish.Loai;
            
            DataTable data =  DataProvider.Instance.ExecuteQuery("EXEC USP_addNewDish @IsLove , @Name , @Video , @Description , @FilePath , @Loai ", new object[] { IsLove , Name, Video, Description, FilePath, Loai });
            
            int dishCode = (int)(data.Rows[0]["Dish"]);

            Step.AddNewStepsToData(newDish.Steps, dishCode);
        }
      
        public DataTable getFilterDishes(string filterQuery)
        {
            
            //string test = "EXEC USP_getDishByTypes @List = N'" + filterQuery + "'";
            //MessageBox.Show(test);
            //return DataProvider.Instance.ExecuteQuery("EXEC USP_getDishByTypes @List = N'Mặn,chay'");
            return DataProvider.Instance.ExecuteQuery("EXEC USP_getDishByTypes @List = N'" + filterQuery + "'");
        }
    }
}
