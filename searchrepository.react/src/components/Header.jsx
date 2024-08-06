import {
    useNavigate
} from "react-router-dom";

export default function Header() {
    const navigate = useNavigate()
    function Logout() {
        localStorage.removeItem('jwt')
        navigate("/")
    }

    return (
        <header className="d-flex justify-content-between">
            <h3 className="m-2">Search repository</h3>
            <button className="btn rounded-5 m-2 border border-1 border-dark" onClick={Logout}>Log out</button>
        </header>
    )
}