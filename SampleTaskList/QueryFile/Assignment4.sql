Create View GetMovieRentingData as 
SELECT  tbl_movierenting.id, ROW_NUMBER() OVER (ORDER BY tbl_movierenting.id) No, tbl_salutation.salutation as Salutation, tbl_customer.full_name AS Name, tbl_customer.address as Address, tbl_movie.movie as Movie,tbl_movierenting.customer_id,tbl_movierenting.movie_id
FROM     tbl_customer, tbl_movierenting, tbl_salutation, tbl_movie
WHERE  tbl_salutation.id = tbl_customer.salutation_id AND tbl_movie.id = tbl_movierenting.movie_id AND tbl_customer.id = tbl_movierenting.customer_id