import logo from './logo.svg';
import './App.css';

import WeatherDisplay from './Components/WeatherDisplay';

function App() {
  return (
    <div className="App">
      <h1>Weather App</h1>
      <WeatherDisplay /> {/* Use the WeatherDisplay component */}
    </div>
  );
}

export default App;
