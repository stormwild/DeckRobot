const requestFontsType = 'REQUEST_FONT';
const receiveFontsType = 'RECEIVE_FONT';
const initialState = { fonts: [], isLoading: false };

export const actionCreators = {
    requestFonts: () => async (dispatch) => {
        dispatch({ type: requestFontsType });

        const url = `api/PowerPoint/Fonts`;
        const response = await fetch(url);
        const fonts = await response.json();

        dispatch({ type: receiveFontsType, fonts });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestFontsType) {
        return {
            ...state,
            isLoading: true
        };
    }

    if (action.type === receiveFontsType) {
        return {
            ...state,
            fonts: action.fonts,
            isLoading: false
        };
    }

    return state;
};
