import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import Auth from './components/Auth.jsx'
import './index.css'
import {
    createBrowserRouter,
    RouterProvider,
    Route,
    Link,
} from "react-router-dom";

const router = createBrowserRouter([
    {
        path: "/",
        element: (
            <Auth />
        )
    },
    {
        path: "/search",
        element: (
            <App />
        )
    }
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode >
        <RouterProvider router={router} />
  </React.StrictMode>,
)
