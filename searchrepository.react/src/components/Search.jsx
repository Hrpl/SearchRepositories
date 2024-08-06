export default function Search({ setSearchString, searchButtonHandler, deleteButtonHandler }) {
    return (
        <section className="row justify-content-center m-0">
            <input className=" col-lg-4 col-sm-10 my-2 p-2 rounded-5" onInput={(e) => setSearchString(e.target.value)}></input>
            <div className="d-flex col-lg-2 col-sm-11 m-0 justify-content-sm-center justify-content-lg-start">
                <button className="btn btn-success m-2 px-3 rounded-5" onClick={searchButtonHandler}>Search</button>
                <button className="btn btn-danger m-2 px-3 rounded-5" onClick={deleteButtonHandler}>Delete</button>
            </div>
        </section>
    )
}