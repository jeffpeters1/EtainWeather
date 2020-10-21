import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSpinner } from '@fortawesome/free-solid-svg-icons'

export class RefreshButton extends Component {

    state = { loading: false };

    fetchData = () => {
        this.state.onClick()

        this.setState({ loading: true })

        setTimeout(() => {
            this.setState({ loading: false });
        }, 1000)
    };

    constructor(props) {
        super(props);
        this.state = { onClick: props.onClick };
    }

    render() {
        const { loading } = this.state;

        return (
            <div className="col-md-4 offset-md-4 text-center mt-4">
                <button className="btn btn-primary btn-block" onClick={this.fetchData} disabled={loading}>                    
                    { loading && <FontAwesomeIcon icon={faSpinner} spin  />}
                    { loading && <span> Loading...</span> }
                    {!loading && <span> Refresh</span> }
                </button>
            </div>
        );
    }

}