# Webject Movie Test

Test is host on [https://webjet-test.herokuapp.com/](https://webjet-test.herokuapp.com/#!/login)

As designed, filmworld API has __1/3 chance__ not working and return empty result. 

Likewise, cinemaworld API has __1/4 chance__ not working and return empty result.

If API not returning result, movie information will be load from browser local storage to give users minimum viable display, but a warning message `Service currently not available, please try again` will be given to indicate the service is currently not available

<p align="center">
  <img alt="VS Code in action" src="https://s3-ap-southeast-2.amazonaws.com/webject-test/Service+Not+Available.PNG">
</p>

#### Token
Login is required to get the access token. In here, please use the test account 
```
Username:test 
Password test
```

<p align="center">
  <img alt="VS Code in action" src="https://s3-ap-southeast-2.amazonaws.com/webject-test/login.PNG">
</p>
