import React, { useState, useEffect } from 'react';
import axios from 'axios';

const WeatherDisplay = () => {
  const [weather, setWeather] = useState(null);

  useEffect(() => {
    const fetchWeather = async () => {
      try {
        const response = await axios.get('http://localhost:5000/weather'); // Assuming your backend is running on port 5000
        setWeather(response.data);
      } catch (error) {
        console.error('Error fetching weather data:', error);
      }
    };

    fetchWeather();
  }, []);

  return (
    <div>
      {weather && (
        <div>
          <h2>Weather for {weather.city}</h2>
          <p>Temperature: {weather.temperature}</p>
          <p>Description: {weather.description}</p>
        </div>
      )}
    </div>
  );
};

export default WeatherDisplay;
