import { useEffect, useState } from 'react'
import './App.css'

type StatusResponse = {
  serviceName: string
  status: string
  timestamp: string
  message: string
  isUnstable: boolean
}

function App() {
  const [status, setStatus] = useState<StatusResponse | null>(null)

  useEffect(() => {
    const loadStatus = () => {
      fetch('https://localhost:7141/api/status')
        .then(response => response.json())
        .then(data => setStatus(data))
        .catch(error => console.error(error))
    }

    loadStatus()

    const interval = setInterval(loadStatus, 3000)

    return () => clearInterval(interval)
  }, [])

  const getStatusClass = () => {
    if (!status) return 'status-card'

    switch (status.status) {
      case 'Healthy':
        return 'status-card healthy'

      case 'Warning':
        return 'status-card warning'

      case 'Unhealthy':
        return 'status-card unhealthy'

      default:
        return 'status-card'
    }
  }

  return (
    <div className="app">
      <h1>ProofWorks ArtistOps</h1>

      {!status && <p>Loading status...</p>}

      {status && (
        <div className={getStatusClass()}>
          <h2>{status.serviceName}</h2>

          <p>
            <strong>Status:</strong> {status.status}
          </p>

          <p>
            <strong>Message:</strong> {status.message}
          </p>

          <p>
            <strong>Timestamp:</strong>{' '}
            {new Date(status.timestamp).toLocaleTimeString()}
          </p>

          <p>
            <strong>Instability Detected:</strong>{' '}
            {status.isUnstable ? 'YES' : 'NO'}
          </p>
        </div>
      )}
    </div>
  )
}

export default App