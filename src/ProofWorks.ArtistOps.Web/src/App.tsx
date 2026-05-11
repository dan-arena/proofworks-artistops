import { useEffect, useMemo, useState } from 'react'
import './App.css'

type StatusResponse = {
  serviceName: string
  status: string
  timestamp: string
  message: string
  isUnstable: boolean
}

type StatusEvent = {
  serviceName: string
  signalType: string
  timestamp: string
  message: string
}

type ViewMode = 'dashboard' | 'history'
type HistoryWindow = '1' | '5' | '15' | '30' | 'all'

const apiBaseUrl = 'https://localhost:7141'

function App() {
  const [status, setStatus] = useState<StatusResponse | null>(null)
  const [history, setHistory] = useState<StatusEvent[]>([])
  const [viewMode, setViewMode] = useState<ViewMode>('dashboard')
  const [historyWindow, setHistoryWindow] = useState<HistoryWindow>('5')

  useEffect(() => {
    const loadStatus = () => {
      fetch(`${apiBaseUrl}/api/status`)
        .then(response => response.json())
        .then(data => setStatus(data))
        .catch(error => console.error(error))
    }

    loadStatus()
    const interval = setInterval(loadStatus, 3000)

    return () => clearInterval(interval)
  }, [])

  const loadHistory = () => {
    fetch(`${apiBaseUrl}/api/status/history`)
      .then(response => response.json())
      .then(data => {
        setHistory(data)
        setViewMode('history')
      })
      .catch(error => console.error(error))
  }

  const filteredHistory = useMemo(() => {
    if (historyWindow === 'all') return history

    const minutes = Number(historyWindow)
    const cutoff = new Date(Date.now() - minutes * 60 * 1000)

    return history.filter(event => new Date(event.timestamp) >= cutoff)
  }, [history, historyWindow])

  const getStatusClass = (currentStatus?: string) => {
    switch (currentStatus) {
      case 'Healthy':
        return 'status-card healthy'

      case 'Warning':
        return 'status-card warning'

      case 'AtRisk':
        return 'status-card at-risk'

      case 'Failure':
        return 'status-card failure'

      case 'Unavailable':
        return 'status-card unavailable'

      default:
        return 'status-card'
    }
  }

  const getStatusBadgeClass = (currentStatus: string) => {
    switch (currentStatus) {
      case 'Healthy':
        return 'status-badge healthy-badge'
      case 'Degraded':
        return 'status-badge warning-badge'
      case 'Failed':
        return 'status-badge failure-badge'
      case 'Unavailable':
        return 'status-badge unavailable-badge'
      default:
        return 'status-badge'
    }
  }

  if (viewMode === 'history') {
    return (
      <div className="app">
        <section className="panel history-panel">
          <div className="history-header">
            <button className="secondary-button" onClick={() => setViewMode('dashboard')}>
              ← Back to Dashboard
            </button>

            <h1>API Status History</h1>
          </div>

          <div className="filter-row">
            <label htmlFor="historyWindow">Time Window:</label>

            <select
              id="historyWindow"
              value={historyWindow}
              onChange={event => setHistoryWindow(event.target.value as HistoryWindow)}
            >
              <option value="1">Last 1 minute</option>
              <option value="5">Last 5 minutes</option>
              <option value="15">Last 15 minutes</option>
              <option value="30">Last 30 minutes</option>
              <option value="all">All</option>
            </select>
          </div>

          <div className="table-shell">
            <table className="history-table">
              <thead>
                <tr>
                  <th>Timestamp</th>
                  <th>Service</th>
                  <th>Signal</th>
                  <th>Message</th>
                </tr>
              </thead>

              <tbody>
                {filteredHistory.map((event, index) => (
                  <tr key={`${event.timestamp}-${index}`}>
                    <td>{new Date(event.timestamp).toLocaleTimeString()}</td>
                    <td>{event.serviceName}</td>
                    <td>
                      <span className={getStatusBadgeClass(event.signalType)}>
                        {event.signalType}
                      </span>
                    </td>
                    <td>{event.message}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          <p className="table-footer">
            Showing {filteredHistory.length} of {history.length} events
          </p>
        </section>
      </div>
    )
  }

  return (
    <div className="app">
      <section className="panel dashboard-panel">
        <h1>ProofWorks ArtistOps</h1>

        {!status && <p className="loading">Loading status...</p>}

        {status && (
          <>
            <button className={getStatusClass(status.status)} onClick={loadHistory}>
              <h2>{status.serviceName}</h2>

              <p>
                <strong>Status:</strong>{' '}
                <span className="status-value">{status.status}</span>
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
                <span className={status.isUnstable ? 'danger-text' : 'ok-text'}>
                  {status.isUnstable ? 'YES' : 'NO'}
                </span>
              </p>
            </button>

            <p className="hint">Click the status card to view history</p>
          </>
        )}
      </section>
    </div>
  )
}

export default App