import { useState, useEffect } from 'react'
import './App.css'

function App() {
  const [weatherData, setWeatherData] = useState<any>([]);
  useEffect(() => {
    async function fetchData() {
      let data = await (await fetch('/api/weatherforecast')).json();
      data = data.map((item: any) => {return (<li key={item.date}>{item.date}, {item.temperatureC}°C, {item.temperatureF}°F, {item.summary}</li>)})
      setWeatherData(data);
    }
    fetchData();
  }, []);

  return (
    <>
      <ul>
        {weatherData}
      </ul>
      <div className="ticks"></div>
    </>
  )
}

export default App
