import { useState, useEffect } from 'react'
//import reactLogo from './assets/react.svg'
//import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [tracks, setTracks] = useState([])

  useEffect(() => {
    fetch("https://localhost:7233/api/tracks")
      .then(response => response.json())
      .then(data => setTracks(data))
      .catch(error => console.error("Error fetching tracks:", error))
  }, []);

  return (
    <div>
      <h1>Music Player</h1>
      <ul>
        {tracks.map(track => (
          <li key={track.id}>
            <strong>{track.title}</strong> by {track.artist}
          </li>
        
        ))}

      </ul>
    </div>
  );
}
  
  /*return (
    <>
      <div>
        <a href="https://vite.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.jsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  )*/


export default App;

