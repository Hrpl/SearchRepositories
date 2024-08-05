import { useState } from 'react'
import { apiGetRepository } from '../services/api-requests.js'
import Card  from '../components/Card.jsx'

export default function Repositories() {

    const [searchString, setSearchString] = useState()
    const [repositories, setRepositories] = useState()

    async function searchButtonHeandler()  {
        const resp = await apiGetRepository(searchString)
        console.log(resp)
        setRepositories(resp)
    }

    return (
        <>
            <section className="d-flex justify-content-center">
                <input className="form-control w-25 m-2" onInput={(e) => setSearchString(e.target.value)}></input>
                <button className="btn btn-success m-2 rounded-4" onClick={searchButtonHeandler }>Search</button>
            </section>

            {
                repositories != undefined ?
                    <div className="row m-2">
                        {repositories.map((repository, index) => {
                            return (

                                <div className="col-3 g-3">
                                    <Card repository={repository}></Card>
                                </div>

                            )
                        })}
                    </div>
                :
                    <div></div>
            }
        </>
    )
}