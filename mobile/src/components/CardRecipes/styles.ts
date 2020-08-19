import styled from 'styled-components/native';

export const Text = styled.Text``;

export const Container = styled.View`
  flex: 1;
  flex-direction: row;
  width: 90%;
  max-height: 200px;
  background: #c7ebf0;
  border-radius: 10px;
  margin: 10px;
`;

export const Img = styled.Image`
  border-radius: 10px;
  flex: 1.5;
`;

export const Data = styled.View`
  flex: 1;
  position: relative;
  justify-content: space-evenly;
  align-items: center;
  margin: 10px;
`;

export const RecipeName = styled.Text`
  text-align: center;
  font-size: 18px;
  font-weight: bold;
`;

export const Favorite = styled.Image`
  position: absolute;
  right: -20px;
  top: -20px;
  height: 35px;
  width: 35px;
  transform: rotate(90deg);
`;
