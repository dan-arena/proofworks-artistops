import { useEffect, useState } from 'react'
import './App.css'

type ApiStatus = {
  application: string
  status: string
  purpose: string
}

function App() {
  const [status, setStatus] = useState<ApiStatus | null>(null)

  useEffect(() => {
    fetch('https://localhost:7141/api/status')
      .then(response => response.json())
      .then(data => setStatus(data))
      .catch(error => console.error(error))
  }, [])

  return (
    <div className="app">
      <h1>ProofWorks ArtistOps</h1>

      {!status && <p>Loading application status...</p>}

      {status && (
        <div className="status-card healthy">
          <h2>{status.application}</h2>
          <p>Status: {status.status}</p>
          <p>{status.purpose}</p>
        </div>
      )}
    </div>
  )
}

export default App