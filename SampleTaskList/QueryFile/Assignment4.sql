Create View vGetAllMovieRentingData as
Select tbl_movierenting.id,tbl_salutation.salutation,tbl_customer.full_name,tbl_customer.address,tbl_movie.movie from tbl_customer,tbl_movierenting,tbl_salutation,tbl_movie Where  tbl_salutation.id = tbl_customer.salutation_id AND tbl_movie.id = tbl_movierenting.movie_id AND tbl_customer.id = tbl_movierenting.customer_id



