import { useState, useRef } from 'react'
import "./../styles/Auth.css"
import { authorize } from './../services/api-requests'
import {
    useNavigate
} from "react-router-dom";

export default function Auth() {

    const [showPassword, setShowPassword] = useState(false)
    const [user, setUser] = useState({
        login: "",
        password: ""
    })
    const errorRef = useRef(null)

    const navigate = useNavigate()

    async function clickLoginButton() {
        const token = await authorize(user.login, user.password)

        if (token != null) {
            navigate("/search")
            errorRef.current.hidden = true
        }
        else {
            errorRef.current.hidden = false
            setUser({
                login: "",
                password: ""
            })
        }
    }

    return (
        <>
            <h2 className="text-center mb-5 mt-3 " style={{ fontWeight: 600 }}>Welcome!</h2>
            <div className="row flex-column align-items-center m-0">
                <div className="d-flex flex-column col-md-4 ">
                    <label className="ms-2" htmlFor="Email"> <b>Email</b></label>
                    <input value={user.login} className="form-control m-2 rounded-3 border-2" id="Email" type="text"
                        onChange={(event) => setUser({ ...user, login: event.target.value })}
                        placeholder="Email" />
                </div>

                <div className="d-flex flex-column col-md-4">
                    <label className="ms-2" ><b>Password</b></label>
                    <span className="input-container">
                        <input value={user.password} className="form-control m-2 rounded-3 border-2" id="password" type={showPassword ? "text" : "password"}
                            onChange={(event) => setUser({ ...user, password: event.target.value })}
                            placeholder="Password" />

                        <span onClick={() => setShowPassword(!showPassword)} className="toggle-password">
                            {showPassword ?

                                <i className="bi bi-eye-slash"></i>
                                :
                                <i className="bi bi-eye "></i>}

                        </span>
                    </span>

                    <section ref={errorRef} className="text-danger ms-2" hidden>
                        <h6 className="bi bi-exclamation-triangle d-inline"></h6>Wrong login or password
                    </section>
                </div>

                <section className="row justify-content-center flex-column">
                    <button className="btn btn-success text-white d-flex align-self-center justify-content-center col-md-2 mt-3 mb-0 rounded-5" style={{
                        fontWeight: 600,
                        margin: "0.5rem"
                    }}
                        onClick={clickLoginButton}>Enter</button>
                    </section>
            </div>
        </>
    )
}