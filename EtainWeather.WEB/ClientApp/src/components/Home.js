import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Weather Forecast</h1>
        <p className="mt-4">Please register / login to view the 5 day weather forecast</p>
      </div>
    );
  }
}
