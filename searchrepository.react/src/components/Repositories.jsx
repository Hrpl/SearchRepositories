import { useState } from 'react'
import { apiGetRepository, apiDeleteRepository } from '../services/api-requests.js'
import Card from './Card.jsx'
import Search from './Search.jsx'

export default function Repositories() {

    const [searchString, setSearchString] = useState()
    const [repositories, setRepositories] = useState()

    async function searchButtonHeandler()  {
        const resp = await apiGetRepository(searchString)
        setRepositories(resp)
    }

    async function deleteButtonHeandler() {
        await apiDeleteRepository(searchString) 

        //после удаления из базы сбрасывает данные на странице
        setSearchString("")
        setRepositories(undefined)
        location.reload()
    }

    return (
        <>
            <Search setSearchString={setSearchString} searchButtonHandler={searchButtonHeandler} deleteButtonHandler={deleteButtonHeandler}></Search>

            {
                repositories != undefined ?
                    <div className="row m-2">
                        {repositories.map((repository, index) => {
                            return (

                                <div className="col-lg-3 col-sm-6 g-3">
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