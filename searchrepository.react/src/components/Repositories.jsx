import {useState } from 'react'
export default function Repositories() {

    const [searchString, setSearchString] = useState()

    const searchButtonHeandler = () => {
        console.log(searchString)
    }

    return (
        <>
            <section className="d-flex justify-content-center">
                <input className="form-control w-25 m-2" onInput={(e) => setSearchString(e.target.value)}></input>
                <button className="btn btn-success m-2 rounded-4" onClick={searchButtonHeandler }>Search</button>
            </section>
        </>
    )
}