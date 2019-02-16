# Webjet Movie Test

Test is host on [https://webjet-test.herokuapp.com/](https://webjet-test.herokuapp.com/#!/movies)

As per [requirement](http://webjetapitest.azurewebsites.net/)

# How to Handle when not all API functions 
The web App is always trying to load movie information from API. If API is not functioning, then web App is going to load movie information from cache

# How to get cheap price
The logic of finding cheap price movie happens in client side angular App ```findCheapMovie()```. Which will compare the movies' price with the same Title and return the cheaper one

