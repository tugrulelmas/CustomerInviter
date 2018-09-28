[![Build Status](https://travis-ci.org/tugrulelmas/CustomerInviter.svg?branch=master)](https://travis-ci.org/tugrulelmas/CustomerInviter)

# CustomerInviter
Invites customers who are within a specific distance of the office for some food and drinks.

# Usage
`docker run tugrulelmas/customer-inviter [--OfficeLocation] [--CustomerPath] [--MaxDistance]`

## Options
`--OfficeLocation=<GPS_COORDINATES>`

Default values is **53.339428,-6.257664**

`--CustomerPath=<URL_OR_PATH_OF_CUSTOMERS_TXT>`

Default values is **https://s3.amazonaws.com/intercom-take-home-test/customers.txt**

You can pass the value of customers.txt on your local machine in debug mode.—e.g., /Downloads/customer.txt

There should be one customer per line and JSON lines formatted. Here is the sample line:
```
{"latitude": "52.986375", "user_id": 12, "name": "Christina McArdle", "longitude": "-6.043701"}
```

`--MaxDistance=<MAX_DISTANCE>`

Distance in km. 

Default values is **100**.

# Debug
- Simply download or clone this repository.
- Be sure you have [.net sdk](https://www.microsoft.com/net/download) on your local machine
- Go to [src](src) folder.
- Feel free to edit files with your best IDE.
- Run the following commands:
  ```
  dotnet build
  dotnet test
  ```

# License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
