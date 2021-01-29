import React, { Component } from 'react';

export class FetchData extends Component {
    displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = { comicses: [], loading: true };

        fetch('https://imr2-303014.oa.r.appspot.com/servak/api/comics')
            .then(response => response.json())
            .then(data => {
                this.setState({ comicses: data[1], loading: false });
            });
    }

    static renderTable(comicses) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {comicses.map(comics =>
                        <tr key={comics.id}>
                            <td>{comics.id}</td>
                            <td>{comics.name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderTable(this.state.comicses);

        return (
            <div>
                <h1>Comics</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}
