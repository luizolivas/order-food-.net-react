import { useState } from 'react'
import { BrowserRouter } from 'react-router-dom'
import AppRouter from './Router'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <BrowserRouter>
      <AppRouter />
    </BrowserRouter>
  )
}

export default App
