import React from "react";
import { ClipLoader } from "react-spinners";
import "./Spinners.css"

type Props = {
  isLoading?: boolean;
};

const Spinners = ({ isLoading = true }: Props) => {
  return (
    <>
      <div id="loading-spinner">
        <ClipLoader
          color="36b7d7"
          loading={isLoading}
          size={35}
          aria-label="Loading Spinner"
          data-testid="loader"
        />
      </div>
    </>
  );
};

export default Spinners;
